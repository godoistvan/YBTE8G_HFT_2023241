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
    new Student { Id = 1, Name = "Kovács István", Email = "kovacs.istvan@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 2, Name = "Nagy János", Email = "nagy.janos@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 3, Name = "Tóth Mária", Email = "toth.maria@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 4, Name = "Varga Katalin", Email = "varga.katalin@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 5, Name = "Horváth Péter", Email = "horvath.peter@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 6, Name = "Kiss Emese", Email = "kiss.emese@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 7, Name = "Farkas Zoltán", Email = "farkas.zoltan@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 8, Name = "Szabó Anna", Email = "szabo.anna@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 9, Name = "Molnár Gábor", Email = "molnar.gabor@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 10, Name = "Balogh Károly", Email = "balogh.karoly@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 4, ClassID = 4 },
    new Student { Id = 11, Name = "Takács Andrea", Email = "takacs.andrea@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 12, Name = "Mészáros Gergő", Email = "meszaros.gergo@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 13, Name = "Papp Krisztina", Email = "papp.krisztina@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 14, Name = "Király Bence", Email = "kiraly.bence@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 15, Name = "Fehér Dóra", Email = "feher.dora@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 16, Name = "Bodor László", Email = "bodor.laszlo@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 17, Name = "Csernai Eszter", Email = "csernai.eszter@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 5, ClassID = 5 },
    new Student { Id = 18, Name = "Fodor Gábor", Email = "fodor.gabor@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 6, ClassID = 6 },
    new Student { Id = 19, Name = "Bencze Enikő", Email = "bencze.eniko@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 6, ClassID = 6 },
    new Student { Id = 20, Name = "Lengyel Zsolt", Email = "lengyel.zsolt@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 6, ClassID = 6 }
};
            List<Course> courses = new List<Course>()
{
    new Course { Id = 2, RecommendedSemester = 2, CourseName = "Algoritmusok és adatszerkezetek", ClassID = 1, Difficulty = 5, Credit = 6 },
    new Course { Id = 3, RecommendedSemester = 3, CourseName = "Operációs rendszerek", ClassID = 2, Difficulty = 4, Credit = 4 },
    new Course { Id = 4, RecommendedSemester = 4, CourseName = "Programozási nyelvek és fordítók", ClassID = 2, Difficulty = 5, Credit = 5 },
    new Course { Id = 5, RecommendedSemester = 3, CourseName = "Mikroelektronika", ClassID = 3, Difficulty = 5, Credit = 5 },
    new Course { Id = 6, RecommendedSemester = 2, CourseName = "Szoftvertervezés és -fejlesztés", ClassID = 3, Difficulty = 4, Credit = 6 },
    new Course { Id = 7, RecommendedSemester = 4, CourseName = "Adatbáziskezelő rendszerek", ClassID = 4, Difficulty = 5, Credit = 5 },
    new Course { Id = 8, RecommendedSemester = 5, CourseName = "Hálózatok és internettechnológiák", ClassID = 4, Difficulty = 4, Credit = 4 },
    new Course { Id = 9, RecommendedSemester = 2, CourseName = "Számítógép-architektúra", ClassID = 5, Difficulty = 5, Credit = 5 },
    new Course { Id = 10, RecommendedSemester = 3, CourseName = "Adatszerkezetek és algoritmusok II", ClassID = 5, Difficulty = 5, Credit = 6 },
    new Course { Id = 11, RecommendedSemester = 4, CourseName = "Számítógépes szimulációk", ClassID = 1, Difficulty = 4, Credit = 4 }
};
        }
        List<Class> classes = new List<Class>()
        {
            new Class{ Id = 1,Semester=1,ClassName="Óbudai Matematikusok",Mascot="Tigris",Specialization="NULL"},
    new Class { Id = 2, Semester = 1, ClassName = "Óbudai Fizikusok", Mascot = "Oroszlán", Specialization = "NULL" },
    new Class { Id = 3, Semester = 2, ClassName = "Óbudai Informatikusok", Mascot = "Leopárd", Specialization = "NULL" },
    new Class { Id = 4, Semester = 2, ClassName = "Óbudai Elektromérnökök", Mascot = "Puma", Specialization = "NULL" },
    new Class { Id = 5, Semester = 3, ClassName = "Óbudai Programozók", Mascot = "Zebra", Specialization = "NULL" },
    new Class { Id = 6, Semester = 3, ClassName = "Óbudai Robotmérnökök", Mascot = "Tehén", Specialization = "NULL" },
    new Class { Id = 7, Semester = 4, ClassName = "Óbudai Mérnökök", Mascot = "Pók", Specialization = "Big Data és üzleti intelligencia" },
    new Class { Id = 8, Semester = 4, ClassName = "Óbudai Természettudósok", Mascot = "Sikló", Specialization = "Felhő szolgáltatási technológiák és IT biztonság" },
    new Class { Id = 9, Semester = 5, ClassName = "Óbudai Tudósok", Mascot = "Denevér", Specialization = "IoT, beágyazott rendszerek és robotika" },
    new Class { Id = 10, Semester = 5, ClassName = "Óbudai Költők", Mascot = "Galamb", Specialization = "Mesterséges Intelligencia" },
    new Class { Id = 11, Semester = 6, ClassName = "Óbudai Gondolkodók", Mascot = "Ökör", Specialization = "Mesterséges intelligencia" },
    new Class { Id = 12, Semester = 6, ClassName = "Óbudai Kutatók", Mascot = "Delfin", Specialization = "Szoftvertervezés és -fejlesztés" },
    new Class { Id = 13, Semester = 7, ClassName = "Óbudai Műszakiak", Mascot = "Kutya", Specialization = "Big Data és üzleti intelligencia" },
    new Class { Id = 14, Semester = 7, ClassName = "Óbudai Filozófusok", Mascot = "Nyúl", Specialization = "Szoftvertervezés és -fejlesztés" }
        };
    }
}
