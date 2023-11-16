using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YBTE8G_HFT_2023241.Models;

namespace YBTE8G_HFT_2023241.Logic.Interfaces
{
    public interface IGameLogic
    {
        void Create(Game game);
        void Delete(int id);
        IEnumerable<Game> ReadAll();
        Game Read(int id);
        void Update(Game game);
    }
}
