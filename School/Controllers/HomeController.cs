using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BL;
using School.BL.Models;
using School.DAL.Entities;
using System.Diagnostics;

namespace School.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger , IUnitOfWork unit , IMapper mapper)
        {
            _logger = logger;
            this.unit = unit;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            
            var model = await unit.Students.GetAll();
            
            var srudents = mapper.Map<IEnumerable<StudentVm>>(model);
            return View(srudents);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var res1 = await unit.Students.GetById(id);
            var res = mapper.Map<StudentVm>(res1);
            return View(res);
        }
        public async Task<IActionResult> Update(int id)
        {
            var dept = await unit.Students.GetById(id);
            var mm = mapper.Map<StudentVm>(dept);
            return View(mm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentVm model)
        {
            var data = mapper.Map<Student>(model);
            
            var qq =  unit.Students.Update(data);
             unit.Complete();

            return RedirectToAction("Index");
        }
        public async Task<JsonResult> Delete1(int id)
        {
            try
            {
                var prod = await unit.Students.GetById(id);
                 unit.Students.Delete(prod);
                 var x = unit.Complete();

                var students = await unit.Students.GetAll();
                var data = mapper.Map<IEnumerable<StudentVm>>(students);
                return Json(data);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return Json(ModelState);

            }
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentVm model)
        {
            var class1 = await unit.Classes.GetById(model.ClassId);
            var data = mapper.Map<Student>(model);
            data.Class = class1;
            

            var qq = await unit.Students.AddStudentAsync(data);
            unit.Complete();

            return RedirectToAction("Index");
        }





    }
}