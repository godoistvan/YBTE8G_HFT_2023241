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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(EducationSystemDbContext ctx) : base(ctx)
        {

        }
        public void UpdateSemester(int id,int newSemesterIn)
        {
            Student old = Read(id);
            old.SemestersIn = newSemesterIn;
            ctx.SaveChanges();
        }
    }
}
