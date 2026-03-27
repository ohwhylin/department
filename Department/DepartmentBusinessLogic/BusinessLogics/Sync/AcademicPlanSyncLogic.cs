using DepartmentContracts.BindingModels;
using DepartmentContracts.BusinessLogicsContracts;
using DepartmentContracts.BusinessLogicsContracts.Sync;
using DepartmentContracts.StoragesContracts;

namespace DepartmentBusinessLogic.BusinessLogics.Sync
{
    public class AcademicPlanSyncLogic : IAcademicPlanSyncLogic
    {
        private readonly IOneCApiService _oneCApiService;
        private readonly IAcademicPlanStorage _academicPlanStorage;

        public AcademicPlanSyncLogic(
            IOneCApiService oneCApiService,
            IAcademicPlanStorage academicPlanStorage)
        {
            _oneCApiService = oneCApiService;
            _academicPlanStorage = academicPlanStorage;
        }

        public async Task SyncAcademicPlansAsync()
        {
            var oneCAcademicPlans = await _oneCApiService.GetAcademicPlansAsync();
            var currentAcademicPlans = _academicPlanStorage.GetFullList() ?? new List<DepartmentContracts.ViewModels.AcademicPlanViewModel>();

            foreach (var oneCPlan in oneCAcademicPlans)
            {
                var existingPlan = currentAcademicPlans.FirstOrDefault(x => x.Id == oneCPlan.Id);

                var model = new AcademicPlanBindingModel
                {
                    Id = oneCPlan.Id,
                    EducationDirectionId = oneCPlan.EducationDirectionId,
                    AcademicCourses = oneCPlan.AcademicCourses,
                    Year = oneCPlan.Year
                };

                if (existingPlan == null)
                {
                    _academicPlanStorage.Insert(model);
                }
                else
                {
                    var needUpdate =
                        existingPlan.EducationDirectionId != oneCPlan.EducationDirectionId ||
                        existingPlan.AcademicCourses != oneCPlan.AcademicCourses ||
                        existingPlan.Year != oneCPlan.Year;

                    if (needUpdate)
                    {
                        _academicPlanStorage.Update(model);
                    }
                }
            }
        }
    }
}