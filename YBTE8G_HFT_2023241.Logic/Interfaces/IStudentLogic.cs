using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Interfaces
{
    public interface IStudentLogic
    {
        void Create(Student student);
        void Delete(int id);
        IEnumerable<Student> ReadAll();
        Student Read(int id);
        void Update(Student student);
    }
}
