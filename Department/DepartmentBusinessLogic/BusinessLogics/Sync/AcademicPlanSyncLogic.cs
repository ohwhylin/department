using DepartmentContracts.BindingModels;
using DepartmentContracts.BusinessLogicsContracts;
using DepartmentContracts.BusinessLogicsContracts.Sync;
using DepartmentContracts.StoragesContracts;
using DepartmentContracts.ViewModels;

namespace DepartmentBusinessLogic.BusinessLogics.Sync
{
    public class AcademicPlanSyncLogic : IAcademicPlanSyncLogic
    {
        private readonly IOneCApiService _oneCApiService;
        private readonly IAcademicPlanStorage _academicPlanStorage;
        private readonly IDisciplineStorage _disciplineStorage;
        private readonly IAcademicPlanRecordStorage _academicPlanRecordStorage;
        private readonly IDisciplineBlockStorage _disciplineBlockStorage;

        public AcademicPlanSyncLogic(
            IOneCApiService oneCApiService,
            IAcademicPlanStorage academicPlanStorage,
            IDisciplineStorage disciplineStorage,
            IAcademicPlanRecordStorage academicPlanRecordStorage,
            IDisciplineBlockStorage disciplineBlockStorage)
        {
            _oneCApiService = oneCApiService;
            _academicPlanStorage = academicPlanStorage;
            _disciplineStorage = disciplineStorage;
            _academicPlanRecordStorage = academicPlanRecordStorage;
            _disciplineBlockStorage = disciplineBlockStorage;
        }

        public async Task SyncAcademicPlansAsync()
        {
            var oneCAcademicPlans = await _oneCApiService.GetAcademicPlansAsync();

            var currentAcademicPlans = _academicPlanStorage.GetFullList() ?? new List<AcademicPlanViewModel>();
            var currentDisciplines = _disciplineStorage.GetFullList() ?? new List<DisciplineViewModel>();
            var currentAcademicPlanRecords = _academicPlanRecordStorage.GetFullList() ?? new List<AcademicPlanRecordViewModel>();
            var currentDisciplineBlocks = _disciplineBlockStorage.GetFullList() ?? new List<DisciplineBlockViewModel>();

            foreach (var oneCPlan in oneCAcademicPlans)
            {
                SyncAcademicPlan(oneCPlan, currentAcademicPlans);

                if (oneCPlan.AcademicPlanRecords == null || oneCPlan.AcademicPlanRecords.Count == 0)
                {
                    continue;
                }

                foreach (var oneCRecord in oneCPlan.AcademicPlanRecords)
                {
                    SyncDiscipline(oneCRecord, currentDisciplines, currentDisciplineBlocks);
                    SyncAcademicPlanRecord(oneCRecord, currentAcademicPlanRecords);
                }
            }

            DeleteRemovedAcademicPlanRecords(oneCAcademicPlans, currentAcademicPlanRecords);
            DeleteRemovedAcademicPlans(oneCAcademicPlans, currentAcademicPlans);
        }

        private void DeleteRemovedAcademicPlanRecords(
        List<DepartmentContracts.Dtos.OneC.AcademicPlanOneCDto> oneCAcademicPlans,
        List<AcademicPlanRecordViewModel> currentAcademicPlanRecords)
            {
                var oneCRecordIds = oneCAcademicPlans
                    .SelectMany(x => x.AcademicPlanRecords ?? new List<DepartmentContracts.Dtos.OneC.AcademicPlanRecordOneCDto>())
                    .Select(x => x.Id)
                    .ToHashSet();

                var recordsToDelete = currentAcademicPlanRecords
                    .Where(x => !oneCRecordIds.Contains(x.Id))
                    .ToList();

                foreach (var record in recordsToDelete)
                {
                    _academicPlanRecordStorage.Delete(new AcademicPlanRecordBindingModel
                    {
                        Id = record.Id
                    });

                    currentAcademicPlanRecords.Remove(record);
                }
            }

        private void DeleteRemovedAcademicPlans(
        List<DepartmentContracts.Dtos.OneC.AcademicPlanOneCDto> oneCAcademicPlans,
        List<AcademicPlanViewModel> currentAcademicPlans)
            {
                var oneCPlanIds = oneCAcademicPlans
                    .Select(x => x.Id)
                    .ToHashSet();

                var plansToDelete = currentAcademicPlans
                    .Where(x => !oneCPlanIds.Contains(x.Id))
                    .ToList();

                foreach (var plan in plansToDelete)
                {
                    _academicPlanStorage.Delete(new AcademicPlanBindingModel
                    {
                        Id = plan.Id
                    });

                    currentAcademicPlans.Remove(plan);
                }
            }

        private void SyncAcademicPlan(
            DepartmentContracts.Dtos.OneC.AcademicPlanOneCDto oneCPlan,
            List<AcademicPlanViewModel> currentAcademicPlans)
        {
            var existingPlan = currentAcademicPlans.FirstOrDefault(x => x.Id == oneCPlan.Id);

            var planModel = new AcademicPlanBindingModel
            {
                Id = oneCPlan.Id,
                EducationDirectionId = oneCPlan.EducationDirectionId,
                AcademicCourses = oneCPlan.AcademicCourses,
                Year = oneCPlan.Year
            };

            if (existingPlan == null)
            {
                _academicPlanStorage.Insert(planModel);

                currentAcademicPlans.Add(new AcademicPlanViewModel
                {
                    Id = planModel.Id,
                    EducationDirectionId = planModel.EducationDirectionId,
                    AcademicCourses = planModel.AcademicCourses,
                    Year = planModel.Year
                });
            }
            else
            {
                var needUpdate =
                    existingPlan.EducationDirectionId != oneCPlan.EducationDirectionId ||
                    existingPlan.AcademicCourses != oneCPlan.AcademicCourses ||
                    existingPlan.Year != oneCPlan.Year;

                if (needUpdate)
                {
                    _academicPlanStorage.Update(planModel);

                    existingPlan.EducationDirectionId = planModel.EducationDirectionId;
                    existingPlan.AcademicCourses = planModel.AcademicCourses;
                    existingPlan.Year = planModel.Year;
                }
            }
        }

        private void SyncDiscipline(
            DepartmentContracts.Dtos.OneC.AcademicPlanRecordOneCDto oneCRecord,
            List<DisciplineViewModel> currentDisciplines,
            List<DisciplineBlockViewModel> currentDisciplineBlocks)
        {
            var existingBlock = currentDisciplineBlocks.FirstOrDefault(x => x.Id == oneCRecord.DisciplineBlockId);
            if (existingBlock == null)
            {
                throw new InvalidOperationException(
                    $"Не найден блок дисциплин с Id = {oneCRecord.DisciplineBlockId} для дисциплины '{oneCRecord.DisciplineName}'.");
            }

            var existingDiscipline = currentDisciplines.FirstOrDefault(x => x.Id == oneCRecord.DisciplineId);

            var disciplineModel = new DisciplineBindingModel
            {
                Id = oneCRecord.DisciplineId,
                DisciplineBlockId = oneCRecord.DisciplineBlockId,
                DisciplineName = oneCRecord.DisciplineName,
                DisciplineShortName = oneCRecord.DisciplineShortName,
                DisciplineDescription = oneCRecord.DisciplineDescription,
                DisciplineBlockBlueAsteriskName = oneCRecord.DisciplineBlockBlueAsteriskName
            };

            if (existingDiscipline == null)
            {
                _disciplineStorage.Insert(disciplineModel);

                currentDisciplines.Add(new DisciplineViewModel
                {
                    Id = disciplineModel.Id,
                    DisciplineBlockId = disciplineModel.DisciplineBlockId,
                    DisciplineName = disciplineModel.DisciplineName,
                    DisciplineShortName = disciplineModel.DisciplineShortName,
                    DisciplineDescription = disciplineModel.DisciplineDescription,
                    DisciplineBlockBlueAsteriskName = disciplineModel.DisciplineBlockBlueAsteriskName
                });
            }
            else
            {
                var needUpdate =
                    existingDiscipline.DisciplineBlockId != oneCRecord.DisciplineBlockId ||
                    existingDiscipline.DisciplineName != oneCRecord.DisciplineName ||
                    existingDiscipline.DisciplineShortName != oneCRecord.DisciplineShortName ||
                    existingDiscipline.DisciplineDescription != oneCRecord.DisciplineDescription ||
                    existingDiscipline.DisciplineBlockBlueAsteriskName != oneCRecord.DisciplineBlockBlueAsteriskName;

                if (needUpdate)
                {
                    _disciplineStorage.Update(disciplineModel);

                    existingDiscipline.DisciplineBlockId = disciplineModel.DisciplineBlockId;
                    existingDiscipline.DisciplineName = disciplineModel.DisciplineName;
                    existingDiscipline.DisciplineShortName = disciplineModel.DisciplineShortName;
                    existingDiscipline.DisciplineDescription = disciplineModel.DisciplineDescription;
                    existingDiscipline.DisciplineBlockBlueAsteriskName = disciplineModel.DisciplineBlockBlueAsteriskName;
                }
            }
        }

        private void SyncAcademicPlanRecord(
            DepartmentContracts.Dtos.OneC.AcademicPlanRecordOneCDto oneCRecord,
            List<AcademicPlanRecordViewModel> currentAcademicPlanRecords)
        {
            var existingRecord = currentAcademicPlanRecords.FirstOrDefault(x => x.Id == oneCRecord.Id);

            var recordModel = new AcademicPlanRecordBindingModel
            {
                Id = oneCRecord.Id,
                AcademicPlanId = oneCRecord.AcademicPlanId,
                DisciplineId = oneCRecord.DisciplineId,
                AcademicPlanRecordParentId = oneCRecord.AcademicPlanRecordParentId,
                InDepartment = oneCRecord.InDepartment,
                Semester = oneCRecord.Semester,
                Zet = oneCRecord.Zet,
                IsParent = oneCRecord.IsParent,
                IsChild = oneCRecord.IsChild,
                IsFacultative = oneCRecord.IsFacultative,
                IsUseInWorkload = oneCRecord.IsUseInWorkload,
                IsActiveSemester = oneCRecord.IsActiveSemester
            };

            if (existingRecord == null)
            {
                _academicPlanRecordStorage.Insert(recordModel);

                currentAcademicPlanRecords.Add(new AcademicPlanRecordViewModel
                {
                    Id = recordModel.Id,
                    AcademicPlanId = recordModel.AcademicPlanId,
                    DisciplineId = recordModel.DisciplineId,
                    AcademicPlanRecordParentId = recordModel.AcademicPlanRecordParentId,
                    InDepartment = recordModel.InDepartment,
                    Semester = recordModel.Semester,
                    Zet = recordModel.Zet,
                    IsParent = recordModel.IsParent,
                    IsChild = recordModel.IsChild,
                    IsFacultative = recordModel.IsFacultative,
                    IsUseInWorkload = recordModel.IsUseInWorkload,
                    IsActiveSemester = recordModel.IsActiveSemester
                });
            }
            else
            {
                var needUpdate =
                    existingRecord.AcademicPlanId != oneCRecord.AcademicPlanId ||
                    existingRecord.DisciplineId != oneCRecord.DisciplineId ||
                    existingRecord.AcademicPlanRecordParentId != oneCRecord.AcademicPlanRecordParentId ||
                    existingRecord.InDepartment != oneCRecord.InDepartment ||
                    existingRecord.Semester != oneCRecord.Semester ||
                    existingRecord.Zet != oneCRecord.Zet ||
                    existingRecord.IsParent != oneCRecord.IsParent ||
                    existingRecord.IsChild != oneCRecord.IsChild ||
                    existingRecord.IsFacultative != oneCRecord.IsFacultative ||
                    existingRecord.IsUseInWorkload != oneCRecord.IsUseInWorkload ||
                    existingRecord.IsActiveSemester != oneCRecord.IsActiveSemester;

                if (needUpdate)
                {
                    _academicPlanRecordStorage.Update(recordModel);

                    existingRecord.AcademicPlanId = recordModel.AcademicPlanId;
                    existingRecord.DisciplineId = recordModel.DisciplineId;
                    existingRecord.AcademicPlanRecordParentId = recordModel.AcademicPlanRecordParentId;
                    existingRecord.InDepartment = recordModel.InDepartment;
                    existingRecord.Semester = recordModel.Semester;
                    existingRecord.Zet = recordModel.Zet;
                    existingRecord.IsParent = recordModel.IsParent;
                    existingRecord.IsChild = recordModel.IsChild;
                    existingRecord.IsFacultative = recordModel.IsFacultative;
                    existingRecord.IsUseInWorkload = recordModel.IsUseInWorkload;
                    existingRecord.IsActiveSemester = recordModel.IsActiveSemester;
                }
            }
        }
    }
}
