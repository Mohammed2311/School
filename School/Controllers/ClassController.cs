using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.BL;
using School.BL.Models;
using School.DAL.Entities;

namespace School.Controllers
{
    [Authorize]
    public class ClassController : Controller
    {
        private readonly ILogger<ClassController> _logger;
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ClassController(ILogger<ClassController> logger, IUnitOfWork unit, IMapper mapper)
        {
            _logger = logger;
            this.unit = unit;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model =await unit.Classes.GetAll();
            var data = mapper.Map<IEnumerable<ClassVm>>(model);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var res1 = await unit.Classes.GetById(id);
            var res = mapper.Map<ClassVm>(res1);
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dept = await unit.Classes.GetById(id);
            var mm = mapper.Map<ClassVm>(dept);
            return View(mm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ClassVm model)
        {
            var data = mapper.Map<Class>(model);
            var qq = unit.Classes.Update(data);
             unit.Complete();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClassVm model)
        {
            var data = mapper.Map<Class>(model);
            var qq =await unit.Classes.AddAsync(data);
             unit.Complete();

            return RedirectToAction("Index");
        }
        public async Task<JsonResult> Delete1(int id)
        {
            try
            {
                var prod = await unit.Classes.GetById(id);
                unit.Classes.Delete(prod);
                unit.Complete();

                var Classs = await unit.Classes.GetAll();
                var data = mapper.Map<IEnumerable<ClassVm>>(Classs);
                return Json(data);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return Json(ModelState);

            }
        }

        [HttpGet]
        public async Task<IActionResult> AddOrRemoveTeachers(int classId)
        {
            ViewBag.classId = classId;
            var class1 = await unit.Classes.GetById(classId);
            if (class1 == null)
            {
                ModelState.AddModelError("", "Role is not exists");
                return View();
            }
            var model = new List<TeacherInClassVm>();
            var teachers = await unit.Teachers.GetAll();
            

            foreach (var item in teachers)
            {
                var teacherInClass = new TeacherInClassVm()
                {
                    TeacherId = item.ID,
                    TeacherName = item.Name,
                    
                    
                };
                
                if (await unit.TeacherClass.IsTeacherInClass(item.ID, class1.ID))
                {
                    teacherInClass.IsSelected = true;
                }
                else
                {
                    teacherInClass.IsSelected = false;
                }
                model.Add(teacherInClass);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveTeachers(List<TeacherInClassVm> model, int classId)
        {
            try
            {
                
                var class1 = await unit.Classes.GetById(classId);

                foreach (var item in model)
                {
                    var user = await unit.Teachers.GetById(item.TeacherId);

                    
                    if (item.IsSelected && !(await unit.TeacherClass.IsTeacherInClass(user.ID, class1.ID)))
                    {
                        //.AddToRoleAsync(user, role.Name);
                        await unit.TeacherClass.AddTeacherToClass(item.TeacherId, class1.ID);
                         unit.Complete();
                    }
                    else if (!item.IsSelected && await unit.TeacherClass.IsTeacherInClass(user.ID, class1.ID))
                    {
                        await unit.TeacherClass.RemoveTeacherFromClass(item.TeacherId, class1.ID);
                         unit.Complete();
                    }

                }

                return RedirectToAction("Update", new { id = classId });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
