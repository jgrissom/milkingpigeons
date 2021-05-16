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
            .Select(ch => new ChallengeJson{ Id = ch.ChallengeId, Name = ch.Name, Pin = ch.Pin }) });
        [HttpPost, Route("api/team")]
        public IActionResult AddTeam([FromBody] Team team)
        {
            // if team id was not included in request, this team must be created
            if (team.TeamId == 0)
            {
                // add new team, first check for duplicate team name
                if (_dataContext.Teams.Any(t => t.Name == team.Name))
                {
                    return Conflict();
                }
                _dataContext.AddTeam(team);
            } else {
                // make sure team name and team id match
                if (_dataContext.Teams.Any(t => t.TeamId == team.TeamId && t.Name == team.Name) == false)
                {
                    return BadRequest();
                }
                // return no content if team name and teamd id already exist
                return NoContent();
            }
            return Ok(team);
        }
    }
}
