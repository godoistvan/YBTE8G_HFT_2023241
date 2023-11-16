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
        void Create(Player student);
        void Delete(int id);
        IEnumerable<Player> ReadAll();
        Player Read(int id);
        void Update(Player student);
    }
}
