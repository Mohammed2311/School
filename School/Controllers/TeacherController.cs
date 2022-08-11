using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.BL;
using School.BL.Models;
using School.DAL.Entities;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public TeacherController(ILogger<TeacherController> logger, IUnitOfWork unit, IMapper mapper)
        {
            _logger = logger;
            this.unit = unit;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = await unit.Teachers.GetAll();

            var srudents = mapper.Map<IEnumerable<TeacherVm>>(model);
            return View(srudents);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherVm model)
        {
            var data = mapper.Map<Teacher>(model);
            var qq = await unit.Teachers.AddAsync(data);
             unit.Complete();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var res1 = await unit.Teachers.GetById(id);
            var res = mapper.Map<TeacherVm>(res1);
            return View(res);
        }
        public async Task<IActionResult> Update(int id)
        {
            var dept = await unit.Teachers.GetById(id);
            var mm = mapper.Map<TeacherVm>(dept);
            return View(mm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TeacherVm model)
        {
            var data = mapper.Map<Teacher>(model);
            var qq = unit.Teachers.Update(data);
             unit.Complete();

            return RedirectToAction("Index");
        }
        public async Task<JsonResult> Delete1(int id)
        {
            try
            {
                var prod = await unit.Teachers.GetById(id);
                unit.Teachers.Delete(prod);
                 unit.Complete();
               
                    var students = await unit.Teachers.GetAll();
                    var data = mapper.Map<IEnumerable<TeacherVm>>(students);
                    return Json(data);
               
                

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return Json(ModelState);

            }
        }

    }
}
