using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBTE8G_HFT_2023241.Logic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YBTE8G_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeamStatController : ControllerBase
    {
        ITeamLogic logic;

        public TeamStatController(ITeamLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public string TeamWithMostLoLPlayers()
        {
            return this.logic.TeamWithMostLoLPlayers();
        }


    }
}
