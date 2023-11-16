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
        public virtual DbSet<SportTeam> Teams { get; set; }
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
                entity.HasOne(student => student.Team)
                .WithMany(classes => classes.Students)
                .HasForeignKey(student => student.SportTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasMany(course => course.Courses)
                .WithMany(classes => classes.Students)
                .UsingEntity(t => t.ToTable("Students"));
            });

            List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "Kovács István", Email = "kovacs.istvan@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4},
    new Student { Id = 2, Name = "Nagy János", Email = "nagy.janos@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4},
    new Student { Id = 3, Name = "Tóth Mária", Email = "toth.maria@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4 },
    new Student { Id = 4, Name = "Varga Katalin", Email = "varga.katalin@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 4},
    new Student { Id = 5, Name = "Horváth Péter", Email = "horvath.peter@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 4 },
    new Student { Id = 6, Name = "Kiss Emese", Email = "kiss.emese@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4},
    new Student { Id = 7, Name = "Farkas Zoltán", Email = "farkas.zoltan@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 4},
    new Student { Id = 8, Name = "Szabó Anna", Email = "szabo.anna@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 4},
    new Student { Id = 9, Name = "Molnár Gábor", Email = "molnar.gabor@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 4 },
    new Student { Id = 10, Name = "Balogh Károly", Email = "balogh.karoly@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 4 },
    new Student { Id = 11, Name = "Takács Andrea", Email = "takacs.andrea@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 5},
    new Student { Id = 12, Name = "Mészáros Gergő", Email = "meszaros.gergo@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 5 },
    new Student { Id = 13, Name = "Papp Krisztina", Email = "papp.krisztina@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5 },
    new Student { Id = 14, Name = "Király Bence", Email = "kiraly.bence@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 5},
    new Student { Id = 15, Name = "Fehér Dóra", Email = "feher.dora@gmail.com", PhoneNumber = "+36301122334", SemestersIn = 5},
    new Student { Id = 16, Name = "Bodor László", Email = "bodor.laszlo@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 5 },
    new Student { Id = 17, Name = "Csernai Eszter", Email = "csernai.eszter@gmail.com", PhoneNumber = "+36308901234", SemestersIn = 5 },
    new Student { Id = 18, Name = "Fodor Gábor", Email = "fodor.gabor@gmail.com", PhoneNumber = "+36301234567", SemestersIn = 6 },
    new Student { Id = 19, Name = "Bencze Enikő", Email = "bencze.eniko@gmail.com", PhoneNumber = "+36304567890", SemestersIn = 6},
    new Student { Id = 20, Name = "Lengyel Zsolt", Email = "lengyel.zsolt@gmail.com", PhoneNumber = "+36307890123", SemestersIn = 6, }
};
            List<Course> courses = new List<Course>()
{
    new Course { Id = 1, RecommendedSemester = 1, CourseName = "Bevezetés a programozásba", Difficulty = 3, Credit = 4 },
    new Course { Id = 2, RecommendedSemester = 2, CourseName = "Algoritmusok és adatszerkezetek", Difficulty = 5, Credit = 6 },
    new Course { Id = 3, RecommendedSemester = 3, CourseName = "Operációs rendszerek", Difficulty = 4, Credit = 4 },
    new Course { Id = 4, RecommendedSemester = 4, CourseName = "Programozási nyelvek és fordítók", Difficulty = 5, Credit = 5 },
    new Course { Id = 5, RecommendedSemester = 3, CourseName = "Mikroelektronika", Difficulty = 5, Credit = 5 },
    new Course { Id = 6, RecommendedSemester = 2, CourseName = "Szoftvertervezés és -fejlesztés", Difficulty = 4, Credit = 6 },
    new Course { Id = 7, RecommendedSemester = 4, CourseName = "Adatbáziskezelő rendszerek", Difficulty = 5, Credit = 5 },
    new Course { Id = 8, RecommendedSemester = 5, CourseName = "Hálózatok és internettechnológiák", Difficulty = 4, Credit = 4 },
    new Course { Id = 9, RecommendedSemester = 2, CourseName = "Számítógép-architektúra", Credit = 5 },
    new Course { Id = 10, RecommendedSemester = 3, CourseName = "Adatszerkezetek és algoritmusok II", Difficulty = 5, Credit = 6 },
    new Course { Id = 11, RecommendedSemester = 4, CourseName = "Számítógépes szimulációk" , Difficulty = 4, Credit = 4 },
};

            List<SportTeam> teams = new List<SportTeam>
{
    new SportTeam { Id = 1, SportName = "Tenisz", Mascot = "Kutya", AreChampions = true },
    new SportTeam { Id = 2, SportName = "Kézilabda", Mascot = "Macska", AreChampions = false },
    new SportTeam { Id = 3, SportName = "Asztalitenisz", Mascot = "Tigris", AreChampions = true },
    new SportTeam { Id = 4, SportName = "Kajak-kenu", Mascot = "Panda", AreChampions = false },
    new SportTeam { Id = 5, SportName = "Síugrás", Mascot = "Medve", AreChampions = true },
    new SportTeam { Id = 6, SportName = "Vívás", Mascot = "Levélállat", AreChampions = false },
    new SportTeam { Id = 7, SportName = "Golf", Mascot = "Krokodil", AreChampions = true },
    new SportTeam { Id = 8, SportName = "Triatlon", Mascot = "Ló", AreChampions = false },
    new SportTeam { Id = 9, SportName = "Evezés", Mascot = "Delfin", AreChampions = true },
    new SportTeam { Id = 10, SportName = "Sakk", Mascot = "Róka", AreChampions = false },
};

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<SportTeam>().HasData(teams);
        }
    }
}
