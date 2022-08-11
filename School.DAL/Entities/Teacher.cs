using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Entities
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]

        public string Name { get; set; }
        
        [Required]
        [Range(23,60)]
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = false;


        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public  ICollection<TeacherClass>Classes { get; set; } = new HashSet<TeacherClass>();  


    }
}
