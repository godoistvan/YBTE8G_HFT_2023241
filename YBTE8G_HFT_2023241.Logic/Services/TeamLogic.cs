using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class ClassLogic : ITeamLogic
    {
        ITeamLogic classRepo;
        public ClassLogic(ITeamLogic classRepo)
        {
             this.classRepo = classRepo;
        }
        public void Create(Team classcreate)
        {
            classRepo.Create(classcreate);
        }

        public void Delete(int id)
        {
            classRepo.Delete(id);
        }

        public Team Read(int id)
        {
            return classRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel osztályt");
        }

        public IEnumerable<Team> ReadAll()
        {
            return classRepo.ReadAll();
        }

        public void Update(Team classupdate)
        {
            classRepo.Update(classupdate);
        }
    }
}
