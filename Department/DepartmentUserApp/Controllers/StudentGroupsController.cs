using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class StudentGroupsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                ViewBag.StudentGroupsList = APIClient.GetRequest<List<StudentGroupViewModel>>("api/StudentGroups/GetStudentGroupList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentGroupsList = new List<StudentGroupViewModel>();
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
                ViewBag.LecturersList = new List<LecturerViewModel>();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
                ViewBag.LecturersList = new List<LecturerViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(StudentGroupBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                    ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                    return View(model);
                }

                APIClient.PostRequest("api/StudentGroups/StudentGroupCreate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.StudentGroupsList = APIClient.GetRequest<List<StudentGroupViewModel>>("api/StudentGroups/GetStudentGroupList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentGroupsList = new List<StudentGroupViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "Некорректный идентификатор";
                    return RedirectToAction("Delete");
                }

                APIClient.PostRequest("api/StudentGroups/StudentGroupDelete", new StudentGroupBindingModel
                {
                    Id = id
                });

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Delete");
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            try
            {
                ViewBag.StudentGroupsList = APIClient.GetRequest<List<StudentGroupViewModel>>("api/StudentGroups/GetStudentGroupList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentGroupsList = new List<StudentGroupViewModel>();
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
                ViewBag.LecturersList = new List<LecturerViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(StudentGroupBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.StudentGroupsList = APIClient.GetRequest<List<StudentGroupViewModel>>("api/StudentGroups/GetStudentGroupList");
                    ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                    ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                    return View(model);
                }

                APIClient.PostRequest("api/StudentGroups/StudentGroupUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentGroupsList = APIClient.GetRequest<List<StudentGroupViewModel>>("api/StudentGroups/GetStudentGroupList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                ViewBag.LecturersList = APIClient.GetRequest<List<LecturerViewModel>>("api/Lecturers/GetLecturerList");
                return View(model);
            }
        }
    }
}
