using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class LecturerDepartmentPostsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                ViewBag.LecturerDepartmentPostsList = APIClient.GetRequest<List<LecturerDepartmentPostViewModel>>("api/core/LecturerDepartmentPosts/GetLecturerDepartmentPostList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.LecturerDepartmentPostsList = new List<LecturerDepartmentPostViewModel>();
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

                var item = APIClient.GetRequest<LecturerDepartmentPostViewModel>($"api/core/LecturerDepartmentPosts/GetLecturerDepartmentPost?id={id}");
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
        public IActionResult Create(LecturerDepartmentPostBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                APIClient.PostRequest("api/core/LecturerDepartmentPosts/LecturerDepartmentPostCreate", model);
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
                ViewBag.LecturerDepartmentPostsList = APIClient.GetRequest<List<LecturerDepartmentPostViewModel>>("api/core/LecturerDepartmentPosts/GetLecturerDepartmentPostList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.LecturerDepartmentPostsList = new List<LecturerDepartmentPostViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(LecturerDepartmentPostBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.LecturerDepartmentPostsList = APIClient.GetRequest<List<LecturerDepartmentPostViewModel>>("api/core/LecturerDepartmentPosts/GetLecturerDepartmentPostList");
                    return View(model);
                }

                APIClient.PostRequest("api/core/LecturerDepartmentPosts/LecturerDepartmentPostUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.LecturerDepartmentPostsList = APIClient.GetRequest<List<LecturerDepartmentPostViewModel>>("api/core/LecturerDepartmentPosts/GetLecturerDepartmentPostList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.LecturerDepartmentPostsList = APIClient.GetRequest<List<LecturerDepartmentPostViewModel>>("api/core/LecturerDepartmentPosts/GetLecturerDepartmentPostList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.LecturerDepartmentPostsList = new List<LecturerDepartmentPostViewModel>();
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

                APIClient.PostRequest("api/core/LecturerDepartmentPosts/LecturerDepartmentPostDelete", new LecturerDepartmentPostBindingModel
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
