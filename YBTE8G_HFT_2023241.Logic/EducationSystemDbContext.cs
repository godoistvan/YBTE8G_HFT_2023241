using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic
{
    public partial  class EducationSystemDbContext : DbContext  
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
    }
}
