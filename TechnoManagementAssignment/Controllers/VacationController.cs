using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnoManagementAssignment.Data;
using TechnoManagementAssignment.Helpers;
using TechnoManagementAssignment.Models;
using TechnoManagementAssignment.Specifications;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechnoManagementAssignment.Controllers
{
    public class VacationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public VacationController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        [HttpGet]
        public IActionResult Create()
        {
            var depts = unitOfWork.Repository<Department>().GetAll()
                                         .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                                         .ToList();
            ViewBag.depts = depts;

            return View();
        }
        [HttpPost]
        public IActionResult Create(Vacation vacation)
        {
                if (ModelState.IsValid)
            {
                unitOfWork.Repository<Vacation>().Add(vacation);
                unitOfWork.Complete();
                return RedirectToAction("Index", "Home", new {message="Created"});
            }
            return View(vacation);
        }
        public IActionResult CheckStartDate(DateTime Start, DateTime End)
        {
            if(Start <  DateTime.Now || (Start > End && End!= new DateTime(1, 1, 1)))
            {
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult CheckEndDate(DateTime End, DateTime Start)
        {
            if (Start == new DateTime(1, 1, 1) || End <  DateTime.Now || End < Start)
            {
                return Json(false);
            }
            return Json(true);
        }
        [HttpGet]
        public ActionResult<Pagination<Vacation>> Index()
        {
            return View();
        }


        [Authorize(Roles = "Manager")]
        public IActionResult GetVacations(VacationSpecParams vparams)
        {
            var spec = new VacationSpecification(vparams);
            var countSpec = new VacaionWithFiltersForCountSpecification(vparams);
            var totalItems = unitOfWork.Repository<Vacation>().Count(countSpec);
            var data = unitOfWork.Repository<Vacation>().GetAllWithSpec(spec);
            return PartialView("_VacationTable",new Pagination<Vacation>(pageIndex: vparams.PageIndex, pageSize: vparams.PageSize, count: totalItems, data: data));
        }

        public IActionResult GetVacationById(int id)
        {
            var spec = new VacationSpecification(id);

            return View(unitOfWork.Repository<Vacation>().GetByIDWithSpec(spec));
        }
    }
}
