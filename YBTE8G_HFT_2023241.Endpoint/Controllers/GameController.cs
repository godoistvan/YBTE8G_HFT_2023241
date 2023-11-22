using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YBTE8G_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic logic;

        public GameController(IGameLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Game value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Game value)
        {
            this.logic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
