using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Entities
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }

    }
}
