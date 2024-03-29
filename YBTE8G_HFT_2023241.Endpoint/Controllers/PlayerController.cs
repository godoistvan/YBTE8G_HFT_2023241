﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBTE8G_HFT_2023241.Logic.Interfaces;
using YBTE8G_HFT_2023241.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YBTE8G_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayerLogic logic;
        public PlayerController(IPlayerLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Player value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Player value)
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
