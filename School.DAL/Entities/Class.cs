using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Entities
{
    public class Class
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int NumOfStudents { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public   ICollection<TeacherClass> Classes { get; set; } = new HashSet<TeacherClass>();
    }
}
