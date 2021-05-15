using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MilkingPigeons.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MilkingPigeons.Controllers
{
    public class APIController : Controller
    {
        // this controller depends on the DataRepository
        private DataContext _dataContext;
        public APIController(DataContext db) => _dataContext = db;

        [HttpGet, Route("api/category")]
        public IEnumerable<CategoryJson> GetCategories() => 
            _dataContext.Categories.Where(c => c.Challenges.Count > 0)
            .Select(c => new CategoryJson{ Id = c.CategoryId, Name = c.Name, Challenges = c.Challenges
            .Where(ch => ch.Active == true)
            .Select(ch => new ChallengeJson{ Id = ch.ChallengeId, Name = ch.Name }) });
        [HttpPost, Route("api/team")]
        //public Team PostTeam([FromBody] Team team) => _dataContext.AddTeam(team.Name);
        public IActionResult PostTeam([FromBody] Team team)
        {
            // first make sure team name is unique
            // if (_dataContext.Teams.Any(t => t.Name == team.Name)) {
            //     return Conflict();
            // }
            // generate pin
            //int next_pin = _dataContext.Teams.Max(t => Convert.ToInt32(t.Pin)) + 1;
            //return Ok(_dataContext.AddTeam(team.Name));
            return Ok();
        }
    }
}
