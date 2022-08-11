using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Models
{
    public class ClassVm
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int NumOfStudents { get; set; }
        
        public  ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
