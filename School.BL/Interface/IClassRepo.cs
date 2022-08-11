using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Interface
{
    public interface IClass:IBaseRepo<Class>
    {
        
        
        Task<Class> FindByName(string name);
        Class FindByStudentID(int studentId);
    }
}
