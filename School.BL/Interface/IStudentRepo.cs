using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Interface
{
    public interface IStudentRepo:IBaseRepo<Student>
    {
        
        Task<List<Student>> GetByClassName(string className );
        
        Task<Student> AddStudentAsync(Student student);


    }
}
