using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBTE8G_HFT_2023241.Logic.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YBTE8G_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GameStatController : ControllerBase
    {
        IGameLogic logic;

        public GameStatController(IGameLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public string MostPlayersInAGame()
        {
            return this.logic.MostPlayersInAGame();
        }

        [HttpGet]
        public IEnumerable<string> ChinesePlayersWithExp()
        {
            return this.logic.ChinesePlayersWithExp();
        }
        [HttpGet]
        public string GameWithMostChineseTeams()
        {
            return this.logic.GameWithMostChineseTeams();
        }
        [HttpGet]
        public string GameWithMostLeagueChampions()
        {
            return this.logic.GameWithMostLeagueChampions();
        }
        
    }
}
