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
    public class StudentRepo : BaseRepo<Student>, IStudentRepo
    {
        private readonly SchoolContext context;

        public StudentRepo(SchoolContext context) : base(context)
        {
            this.context = context;
        }

      

        public async Task<List<Student>> GetByClassName(string className)
        {
            return await context.Students.Where(s => s.Class.Name == className).ToListAsync();
        }
      

        public async Task<Student> AddStudentAsync(Student student)
        {
            var student1 = new Student()
            {
                Name = student.Name,
                Age = student.Age,
                ClassId = student.ClassId,
                 IsDeleted =false,
                 TotalGradien = student.TotalGradien
            };
            await context.AddAsync(student1);
            return student1;
        }
    }
}
