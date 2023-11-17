using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Services
{
    public class PlayerLogic : IPlayerLogic
    {
        IPlayerLogic studentRepo;
        public PlayerLogic(IPlayerLogic studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        public void Create(Player student)
        {
            studentRepo.Create(student);
        }

        public void Delete(int id)
        {
            studentRepo.Delete(id);
        }

        public Player Read(int id)
        {
            return studentRepo.Read(id) ?? throw new ArgumentNullException("Nem találtunk ilyen id-vel hallgatót");
        }

        public IEnumerable<Player> ReadAll()
        {
            return studentRepo.ReadAll();
        }

        public void Update(Player student)
        {
            studentRepo.Update(student);
        }
    }
}
