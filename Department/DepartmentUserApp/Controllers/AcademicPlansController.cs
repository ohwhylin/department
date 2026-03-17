using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class AcademicPlansController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
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

                var item = APIClient.GetRequest<AcademicPlanViewModel>($"api/AcademicPlans/GetAcademicPlan?id={id}");
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
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(AcademicPlanBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                    return View(model);
                }

                APIClient.PostRequest("api/AcademicPlans/AcademicPlanCreate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            try
            {
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
                ViewBag.EducationDirectionsList = new List<EducationDirectionViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(AcademicPlanBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                    ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                    return View(model);
                }

                APIClient.PostRequest("api/AcademicPlans/AcademicPlanUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.EducationDirectionsList = APIClient.GetRequest<List<EducationDirectionViewModel>>("api/EducationDirections/GetEducationDirectionList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
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

                APIClient.PostRequest("api/AcademicPlans/AcademicPlanDelete", new AcademicPlanBindingModel
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
