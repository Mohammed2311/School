using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Entities
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(6,18)]
        public int Age { get; set; }
        public string TotalGradien { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("ClassId")]
        public  Class Class { get; set; }
        public int ClassId { get; set; }


    }
}
