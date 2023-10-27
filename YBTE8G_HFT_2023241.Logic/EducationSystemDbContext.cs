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
    public partial class EducationSystemDbContext : DbContext
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
              .UseLazyLoadingProxies();


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
            List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "Kovács István", Email = "kovacs.istvan@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 3, ClassID = 2 },
    new Student { Id = 2, Name = "Nagy János", Email = "nagy.janos@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 3, ClassID = 2 },
    new Student { Id = 3, Name = "Tóth Mária", Email = "toth.maria@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4, ClassID = 3 },
    new Student { Id = 4, Name = "Varga Katalin", Email = "varga.katalin@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 2, ClassID = 4 },
    new Student { Id = 5, Name = "Horváth Péter", Email = "horvath.peter@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 6, Name = "Kiss Emese", Email = "kiss.emese@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 3, ClassID = 1 },
    new Student { Id = 7, Name = "Farkas Zoltán", Email = "farkas.zoltan@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 4, ClassID = 2 },
    new Student { Id = 8, Name = "Szabó Anna", Email = "szabo.anna@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 3, ClassID = 3 },
    new Student { Id = 9, Name = "Molnár Gábor", Email = "molnar.gabor@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5, ClassID = 4 },
    new Student { Id = 10, Name = "Balogh Károly", Email = "balogh.karoly@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 2, ClassID = 5 },
    new Student { Id = 11, Name = "Takács Andrea", Email = "takacs.andrea@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 4, ClassID = 1 },
    new Student { Id = 11, Name = "Takács Andrea", Email = "takacs.andrea@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 4, ClassID = 1 },
    new Student { Id = 12, Name = "Mészáros Gergő", Email = "meszaros.gergo@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 3, ClassID = 2 },
    new Student { Id = 13, Name = "Papp Krisztina", Email = "papp.krisztina@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5, ClassID = 3 },
    new Student { Id = 14, Name = "Király Bence", Email = "kiraly.bence@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 2, ClassID = 4 },
    new Student { Id = 15, Name = "Fehér Dóra", Email = "feher.dora@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 4, ClassID = 5 },
    new Student { Id = 16, Name = "Bodor László", Email = "bodor.laszlo@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 3, ClassID = 1 },
    new Student { Id = 17, Name = "Csernai Eszter", Email = "csernai.eszter@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 5, ClassID = 2 },
    new Student { Id = 18, Name = "Fodor Gábor", Email = "fodor.gabor@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 2, ClassID = 3 },
    new Student { Id = 19, Name = "Bencze Enikő", Email = "bencze.eniko@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4, ClassID = 4 },
};
        
        }
    }
}
