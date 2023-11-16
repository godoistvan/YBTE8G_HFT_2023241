using System;
using System.Linq;
using YBTE8G_HFT_2023241.Logic;

namespace YBTE8G_HFT_2023241
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EducationSystemDbContext dbseed = new EducationSystemDbContext();
            dbseed.Students.ToArray();
            dbseed.Courses.ToArray();
            dbseed.Teams.ToArray();
            ;
            Console.WriteLine("Hello World!");
        }
    }
}
