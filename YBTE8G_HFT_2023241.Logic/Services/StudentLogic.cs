using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class StudentLogic : IStudentLogic
    {
        IStudentLogic studentRepo;
        public StudentLogic(IStudentLogic studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        public void Create(Student student)
        {
            studentRepo.Create(student);
        }

        public void Delete(int id)
        {
            studentRepo.Delete(id);
        }

        public Student Read(int id)
        {
            return studentRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel hallgatót");
        }

        public IEnumerable<Student> ReadAll()
        {
            return studentRepo.ReadAll();
        }

        public void Update(Student student)
        {
            studentRepo.Update(student);
        }
    }
}
