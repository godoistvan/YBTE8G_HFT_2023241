using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EducationSystemDbContext ctx) : base(ctx)
        {
        }
        public void UpdateTeacherName(int id,string newTeacherName)
        {
            Course old = Read(id);
            old.TeacherName = newTeacherName;
            ctx.SaveChanges();
        }
    }
}
