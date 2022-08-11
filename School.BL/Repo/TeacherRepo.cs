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
    public class TeacherRepo : BaseRepo<Teacher>
    {
        private readonly SchoolContext context;

        public TeacherRepo(SchoolContext context) : base(context)
        {
            this.context = context;
        }

        public void Delete(Teacher teacher)
        {
            teacher.IsDeleted = true;
            context.Teachers.Remove(teacher);
        }
        public async Task<List<Teacher>> GetAll()
        {
            return await context.Teachers.ToListAsync();

            
        }



    }
}
