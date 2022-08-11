using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Interface
{
    public interface ITeacherClassRepo : IBaseRepo<TeacherClass>
    {
        Task<TeacherClass> FindByName(string name);
        
        Task<bool> IsTeacherInClass(int teacherId  , int classId);
        Task AddTeacherToClass(int teacherId, int classId);
        Task RemoveTeacherFromClass(int teacherId, int classId);
    }
}
