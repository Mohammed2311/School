using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.BL.Models;

namespace School.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentVm>();
            CreateMap<StudentVm, Student>();

            CreateMap<Teacher, TeacherVm>();
            CreateMap<TeacherVm, Teacher>();

            CreateMap<ClassVm, Class>();
            CreateMap<Class, ClassVm>();

            


        }

    }
}
