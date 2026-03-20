using Microsoft.AspNetCore.Mvc;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                ViewBag.EducationDirectionCount =
                    APIClient.GetRequest<List<EducationDirectionViewModel>>("api/core/EducationDirections/GetEducationDirectionList")?.Count ?? 0;

                ViewBag.LecturerCount =
                    APIClient.GetRequest<List<LecturerViewModel>>("api/core/Lecturers/GetLecturerList")?.Count ?? 0;

                ViewBag.StudentCount =
                    APIClient.GetRequest<List<StudentViewModel>>("api/core/Students/GetStudentList")?.Count ?? 0;

                ViewBag.StudentGroupCount =
                    APIClient.GetRequest<List<StudentGroupViewModel>>("api/core/StudentGroups/GetStudentGroupList")?.Count ?? 0;

                ViewBag.DisciplineCount =
                    APIClient.GetRequest<List<DisciplineViewModel>>("api/core/Disciplines/GetDisciplineList")?.Count ?? 0;

                ViewBag.AcademicPlanCount =
                    APIClient.GetRequest<List<AcademicPlanViewModel>>("api/core/AcademicPlans/GetAcademicPlanList")?.Count ?? 0;

                ViewBag.StudentOrderCount =
                    APIClient.GetRequest<List<StudentOrderViewModel>>("api/core/StudentOrders/GetStudentOrderList")?.Count ?? 0;

                ViewBag.ClassroomCount =
                    APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList")?.Count ?? 0;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                ViewBag.EducationDirectionCount = 0;
                ViewBag.LecturerCount = 0;
                ViewBag.StudentCount = 0;
                ViewBag.StudentGroupCount = 0;
                ViewBag.DisciplineCount = 0;
                ViewBag.AcademicPlanCount = 0;
                ViewBag.StudentOrderCount = 0;
                ViewBag.ClassroomCount = 0;
            }

            return View();
        }
    }
}