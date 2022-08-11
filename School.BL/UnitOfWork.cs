using School.BL.Interface;
using School.BL.Repo;
using School.DAL.Context;
using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext context;

        public IClass Classes { get; private set; }

        public IStudentRepo Students { get; private set; }
        public IBaseRepo<Teacher> Teachers { get; private set; }

        public ITeacherClassRepo TeacherClass { get; private set; }
        public UnitOfWork(SchoolContext context)
        {
            this.context = context;
            Students = new StudentRepo(context);
            Teachers = new TeacherRepo(context);
            Classes = new ClassRepo(context);
            TeacherClass = new TeacherClassRepo(context);
        }

        public  int Complete()
        {
            
            return  context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
