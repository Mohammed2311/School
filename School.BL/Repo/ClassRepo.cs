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
    public class ClassRepo : BaseRepo<Class>, IClass
    {
        private readonly SchoolContext context;

        public ClassRepo(SchoolContext context) : base(context)
        {
            this.context = context;
        }

       

        public async Task<Class> FindByName(string name)
        {
            return await context.Classes.Where(c=>c.Name == name).FirstOrDefaultAsync();
        }

        public  Class FindByStudentID(int studentId)
        {
            var student =  context.Students.Where(s => s.ID == studentId).FirstOrDefault();
            return context.Classes.Where(c => c.ID == student.Class.ID).FirstOrDefault();

        }

    }
}
