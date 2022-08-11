using Microsoft.EntityFrameworkCore;
using School.BL.Interface;
using School.DAL.Context;
using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Repo
{
    public class TeacherClassRepo : BaseRepo<TeacherClass>, ITeacherClassRepo
    {
        private readonly SchoolContext context;

        public TeacherClassRepo(SchoolContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddTeacherToClass(int teacherId, int classId)
        {
            var class1 =await context.Classes.Where(c => c.ID == classId).FirstOrDefaultAsync();
            var teacherClass = new TeacherClass()
            {
                TeacherId = teacherId,
                ClassId = class1.ID,
                ClassName = class1.Name
            };

            if (await IsTeacherInClass(teacherId , classId) == false)
            {
                await context.TeacherClasses.AddAsync(teacherClass);
            }
        }

        public async Task<TeacherClass> FindByName(string name)
        {
            return await context.TeacherClasses.Where(e => e.ClassName == name).FirstOrDefaultAsync();

        }
        public async Task<List<TeacherClass>> GetAll() => await context.TeacherClasses.ToListAsync();

        public async Task<bool> IsTeacherInClass(int teacherId, int classId)
        {
            var teacher =await context.Teachers.Where(t => t.ID == teacherId && t.IsDeleted == false).FirstOrDefaultAsync();
            var class1 = await context.Classes.Where(t => t.ID == classId && t.IsDeleted ==false ).FirstOrDefaultAsync();
            var classTeacher = await context.TeacherClasses.FirstOrDefaultAsync(t => t.TeacherId == teacherId && t.ClassId == classId);
            if (teacher?.ID ==classTeacher?.TeacherId
                && class1?.ID == classTeacher?.ClassId)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }

        public async Task RemoveTeacherFromClass(int teacherId, int classId)
        {
            var class1 = await context.Classes.Where(c => c.ID == classId).FirstOrDefaultAsync();
            var teacherClass = new TeacherClass()
            {
                TeacherId = teacherId,
                ClassId = class1.ID,
                ClassName = class1.Name
            };

            if (await IsTeacherInClass(teacherId, classId) )
            {
                context.TeacherClasses.Remove(teacherClass);
            }
        }
    }
}
