using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;
using YBTE8G_HFT_2023241.Repository.Interfaces;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> PlayerRepo;
        public PlayerLogic(IRepository<Player> repo)
        {
            PlayerRepo = repo;
        }
        public void Create(Player student)
        {
            PlayerRepo.Create(student);
        }

        public void Delete(int id)
        {
            PlayerRepo.Delete(id);
        }

        public Player Read(int id)
        {
            return PlayerRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel hallgatót");
        }

        public IEnumerable<Player> ReadAll()
        {
            return PlayerRepo.ReadAll();
        }

        public void Update(Player student)
        {
            PlayerRepo.Update(student);
        }
    }
}
