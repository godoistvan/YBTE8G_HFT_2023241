using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Interfaces
{
    internal interface IClassLogic
    {
        void Create(Class classcreate);
        void Delete(int id);
        IEnumerable<Class> ReadAll();
        Class Read(int id);
        void Update(Course classupdate);
    }
}
