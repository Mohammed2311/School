using School.BL.Interface;
using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL
{
    public interface IUnitOfWork : IDisposable
    {
       IClass Classes { get; }
        IStudentRepo Students { get; }
        
        IBaseRepo<Teacher> Teachers { get; }
        ITeacherClassRepo TeacherClass { get; }
        int Complete();
    }
}
