using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class StudentOrdersController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                ViewBag.StudentOrdersList = APIClient.GetRequest<List<StudentOrderViewModel>>("api/StudentOrders/GetStudentOrderList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentOrdersList = new List<StudentOrderViewModel>();
                return View();
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
        public IActionResult Create(StudentOrderBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                APIClient.PostRequest("api/StudentOrders/StudentOrderCreate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.StudentOrdersList = APIClient.GetRequest<List<StudentOrderViewModel>>("api/StudentOrders/GetStudentOrderList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentOrdersList = new List<StudentOrderViewModel>();
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

                APIClient.PostRequest("api/StudentOrders/StudentOrderDelete", new StudentOrderBindingModel
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
                ViewBag.StudentOrdersList = APIClient.GetRequest<List<StudentOrderViewModel>>("api/StudentOrders/GetStudentOrderList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentOrdersList = new List<StudentOrderViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(StudentOrderBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.StudentOrdersList = APIClient.GetRequest<List<StudentOrderViewModel>>("api/StudentOrders/GetStudentOrderList");
                    return View(model);
                }

                APIClient.PostRequest("api/StudentOrders/StudentOrderUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.StudentOrdersList = APIClient.GetRequest<List<StudentOrderViewModel>>("api/StudentOrders/GetStudentOrderList");
                return View(model);
            }
        }
    }
}
