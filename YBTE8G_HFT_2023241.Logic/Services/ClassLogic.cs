using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class ClassLogic : IClassLogic
    {
        IClassLogic classRepo;
        public ClassLogic(IClassLogic classRepo)
        {
             this.classRepo = classRepo;
        }
        public void Create(Class classcreate)
        {
            classRepo.Create(classcreate);
        }

        public void Delete(int id)
        {
            classRepo.Delete(id);
        }

        public Class Read(int id)
        {
            return classRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel osztályt");
        }

        public IEnumerable<Class> ReadAll()
        {
            return classRepo.ReadAll();
        }

        public void Update(Class classupdate)
        {
            classRepo.Update(classupdate);
        }
    }
}
