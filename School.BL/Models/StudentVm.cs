using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BL.Models
{
    public class StudentVm
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(6, 18)]
        public int Age { get; set; }
        [Required]
        public string? TotalGradien { get; set; }
        public  Class? Class { get; set; }
        public int ClassId { get; set; }

    }
}
