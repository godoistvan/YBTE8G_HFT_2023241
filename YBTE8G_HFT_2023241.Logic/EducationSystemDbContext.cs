using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.SqlServer;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic
{
    public partial  class EducationSystemDbContext : DbContext  
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public EducationSystemDbContext()
        {
           this.Database.EnsureCreated();
        }
        public EducationSystemDbContext(DbContextOptions<EducationSystemDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
              .UseInMemoryDatabase("carshopdb")
              .UseLazyLoadingProxies(); // lazy load bekapcsolása


            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(student => student.Class)
                .WithMany(classes => classes.Students)
                .HasForeignKey(student => student.ClassID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(course => course.Class)
                .WithMany(classes => classes.Courses)
                .HasForeignKey(course => course.ClassID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
