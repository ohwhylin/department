using DepartmentContracts.BusinessLogicsContracts.Sync;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly IAcademicPlanSyncLogic _academicPlanSyncLogic;

        public SyncController(IAcademicPlanSyncLogic academicPlanSyncLogic)
        {
            _academicPlanSyncLogic = academicPlanSyncLogic;
        }

        [HttpPost("academic-plans")]
        public async Task<IActionResult> SyncAcademicPlans()
        {
            try
            {
                await _academicPlanSyncLogic.SyncAcademicPlansAsync();
                return Ok("Academic plans synchronization completed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "Internal server error",
                    details = ex.Message
                });
            }
        }
    }
}