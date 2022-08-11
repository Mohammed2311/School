

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Context
{
    public class SchoolContext:IdentityDbContext
    {
        

        public SchoolContext(DbContextOptions<SchoolContext> options)
      : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherClass>().HasKey(tc => new { tc.TeacherId, tc.ClassId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Class>  Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
    }
}
