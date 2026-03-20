using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class ClassroomsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                ViewBag.ClassroomsList = APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.ClassroomsList = new List<ClassroomViewModel>();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "Некорректный идентификатор";
                    return RedirectToAction("List");
                }

                var item = APIClient.GetRequest<ClassroomViewModel>($"api/core/Classrooms/GetClassroom?id={id}");
                if (item == null)
                {
                    TempData["Error"] = "Запись не найдена";
                    return RedirectToAction("List");
                }

                return View(item);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(ClassroomBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                APIClient.PostRequest("api/core/Classrooms/ClassroomCreate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            try
            {
                ViewBag.ClassroomsList = APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.ClassroomsList = new List<ClassroomViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(ClassroomBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ClassroomsList = APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList");
                    return View(model);
                }

                APIClient.PostRequest("api/core/Classrooms/ClassroomUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.ClassroomsList = APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.ClassroomsList = APIClient.GetRequest<List<ClassroomViewModel>>("api/core/Classrooms/GetClassroomList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.ClassroomsList = new List<ClassroomViewModel>();
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

                APIClient.PostRequest("api/core/Classrooms/ClassroomDelete", new ClassroomBindingModel
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
    }
}
