using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;

namespace DepartmentUserApp.Controllers
{
    public class AcademicPlanRecordsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View();
            //catch (Exception ex)
            //{
            //    TempData["Error"] = ex.Message;
            //    ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
            //    ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
            //    ViewBag.DisciplinesList = new List<DisciplineViewModel>();
            //    ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
            //    return View();
            //}
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
                ViewBag.DisciplinesList = new List<DisciplineViewModel>();
                ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(AcademicPlanRecordBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                    ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                    ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                    return View(model);
                }

                APIClient.PostRequest("api/AcademicPlanRecords/AcademicPlanRecordCreate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete()
        {
            try
            {
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
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

                APIClient.PostRequest("api/AcademicPlanRecords/AcademicPlanRecordDelete", new AcademicPlanRecordBindingModel
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
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
                ViewBag.AcademicPlansList = new List<AcademicPlanViewModel>();
                ViewBag.DisciplinesList = new List<DisciplineViewModel>();
                ViewBag.AcademicPlanRecordsList = new List<AcademicPlanRecordViewModel>();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(AcademicPlanRecordBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                    ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                    ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                    ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                    return View(model);
                }

                APIClient.PostRequest("api/AcademicPlanRecords/AcademicPlanRecordUpdate", model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                ViewBag.AcademicPlansList = APIClient.GetRequest<List<AcademicPlanViewModel>>("api/AcademicPlans/GetAcademicPlanList");
                ViewBag.DisciplinesList = APIClient.GetRequest<List<DisciplineViewModel>>("api/Disciplines/GetDisciplineList");
                ViewBag.AcademicPlanRecordsList = APIClient.GetRequest<List<AcademicPlanRecordViewModel>>("api/AcademicPlanRecords/GetAcademicPlanRecordList");
                return View(model);
            }
        }
    }
}
