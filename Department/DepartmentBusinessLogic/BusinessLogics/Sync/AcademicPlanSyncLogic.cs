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
        private readonly IAcademicPlanRecordStorage _academicPlanRecordStorage;

        public AcademicPlanSyncLogic(
            IOneCApiService oneCApiService,
            IAcademicPlanStorage academicPlanStorage,
            IAcademicPlanRecordStorage academicPlanRecordStorage)
        {
            _oneCApiService = oneCApiService;
            _academicPlanStorage = academicPlanStorage;
            _academicPlanRecordStorage = academicPlanRecordStorage;
        }

        public async Task SyncAcademicPlansAsync()
        {
            var oneCAcademicPlans = await _oneCApiService.GetAcademicPlansAsync();

            var currentAcademicPlans = _academicPlanStorage.GetFullList() ?? new List<AcademicPlanViewModel>();
            var currentAcademicPlanRecords = _academicPlanRecordStorage.GetFullList() ?? new List<AcademicPlanRecordViewModel>();

            foreach (var oneCPlan in oneCAcademicPlans)
            {
                SyncAcademicPlan(oneCPlan, currentAcademicPlans);

                if (oneCPlan.AcademicPlanRecords == null || oneCPlan.AcademicPlanRecords.Count == 0)
                {
                    continue;
                }

                foreach (var oneCRecord in oneCPlan.AcademicPlanRecords)
                {
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

        private void SyncAcademicPlanRecord(
            DepartmentContracts.Dtos.OneC.AcademicPlanRecordOneCDto oneCRecord,
            List<AcademicPlanRecordViewModel> currentAcademicPlanRecords)
        {
            var existingRecord = currentAcademicPlanRecords.FirstOrDefault(x => x.Id == oneCRecord.Id);

            var recordModel = new AcademicPlanRecordBindingModel
            {
                Id = oneCRecord.Id,
                AcademicPlanId = oneCRecord.AcademicPlanId,
                Index = oneCRecord.Index,
                Name = oneCRecord.Name,
                Semester = oneCRecord.Semester,
                Zet = oneCRecord.Zet,
                AcademicHours = oneCRecord.AcademicHours,
                Exam = oneCRecord.Exam,
                Pass = oneCRecord.Pass,
                GradedPass = oneCRecord.GradedPass,
                CourseWork = oneCRecord.CourseWork,
                CourseProject = oneCRecord.CourseProject,
                Rgr = oneCRecord.Rgr,
                Lectures = oneCRecord.Lectures,
                LaboratoryHours = oneCRecord.LaboratoryHours,
                PracticalHours = oneCRecord.PracticalHours
            };

            if (existingRecord == null)
            {
                _academicPlanRecordStorage.Insert(recordModel);

                currentAcademicPlanRecords.Add(new AcademicPlanRecordViewModel
                {
                    Id = recordModel.Id,
                    AcademicPlanId = recordModel.AcademicPlanId,
                    Index = recordModel.Index,
                    Name = recordModel.Name,
                    Semester = recordModel.Semester,
                    Zet = recordModel.Zet,
                    AcademicHours = recordModel.AcademicHours,
                    Exam = recordModel.Exam,
                    Pass = recordModel.Pass,
                    GradedPass = recordModel.GradedPass,
                    CourseWork = recordModel.CourseWork,
                    CourseProject = recordModel.CourseProject,
                    Rgr = recordModel.Rgr,
                    Lectures = recordModel.Lectures,
                    LaboratoryHours = recordModel.LaboratoryHours,
                    PracticalHours = recordModel.PracticalHours
                });
            }
            else
            {
                var needUpdate =
                    existingRecord.AcademicPlanId != oneCRecord.AcademicPlanId ||
                    existingRecord.Index != oneCRecord.Index ||
                    existingRecord.Name != oneCRecord.Name ||
                    existingRecord.Semester != oneCRecord.Semester ||
                    existingRecord.Zet != oneCRecord.Zet ||
                    existingRecord.AcademicHours != oneCRecord.AcademicHours ||
                    existingRecord.Exam != oneCRecord.Exam ||
                    existingRecord.Pass != oneCRecord.Pass ||
                    existingRecord.GradedPass != oneCRecord.GradedPass ||
                    existingRecord.CourseWork != oneCRecord.CourseWork ||
                    existingRecord.CourseProject != oneCRecord.CourseProject ||
                    existingRecord.Rgr != oneCRecord.Rgr ||
                    existingRecord.Lectures != oneCRecord.Lectures ||
                    existingRecord.LaboratoryHours != oneCRecord.LaboratoryHours ||
                    existingRecord.PracticalHours != oneCRecord.PracticalHours;

                if (needUpdate)
                {
                    _academicPlanRecordStorage.Update(recordModel);

                    existingRecord.AcademicPlanId = recordModel.AcademicPlanId;
                    existingRecord.Index = recordModel.Index;
                    existingRecord.Name = recordModel.Name;
                    existingRecord.Semester = recordModel.Semester;
                    existingRecord.Zet = recordModel.Zet;
                    existingRecord.AcademicHours = recordModel.AcademicHours;
                    existingRecord.Exam = recordModel.Exam;
                    existingRecord.Pass = recordModel.Pass;
                    existingRecord.GradedPass = recordModel.GradedPass;
                    existingRecord.CourseWork = recordModel.CourseWork;
                    existingRecord.CourseProject = recordModel.CourseProject;
                    existingRecord.Rgr = recordModel.Rgr;
                    existingRecord.Lectures = recordModel.Lectures;
                    existingRecord.LaboratoryHours = recordModel.LaboratoryHours;
                    existingRecord.PracticalHours = recordModel.PracticalHours;
                }
            }
        }
    }
}