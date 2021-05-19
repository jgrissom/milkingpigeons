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
                    return BadRequest();
                }
                _dataContext.AddTeam(team);
                return Ok(team);
            } else {
                // make sure team name and team id match
                if (_dataContext.Teams.Any(t => t.TeamId == team.TeamId && t.Name == team.Name) == false)
                {
                    return BadRequest();
                }
                // return no content if team name and teamd id already exist
                return NoContent();
            }
        }
        
        [HttpGet, Route("api/teamchallenge/{id}")]
        public IActionResult GetTeamChallenges(int id)
        {
            var teams = _dataContext.TeamChallenges.Where(tc => tc.ChallengeId == id).Select(tc => new Team{ TeamId = tc.TeamId, Name = tc.Team.Name });
            if (teams.Count() == 0)
            {
                return NoContent();
            }
            return Ok(teams);
        }
        [HttpPost, Route("api/teamchallenge")]
        public IActionResult AddTeamToChallenge([FromBody] TeamChallengeJson teamChallengeJson)
        {
            var challenge = _dataContext.Challenges.FirstOrDefault(ch => ch.Pin == teamChallengeJson.Pin && ch.Active == true);
            // check for valid challenge pin / valid team id
            if (challenge == null || !_dataContext.Teams.Any(t => t.TeamId == teamChallengeJson.TeamId))
            {
                 return BadRequest();
            } else if (_dataContext.TeamChallenges.Any(tc => tc.ChallengeId == challenge.ChallengeId && tc.TeamId == teamChallengeJson.TeamId)) {
                // duplicate TeamId / ChallengeId
                return Conflict();
            }
            
            _dataContext.AddTeamChallenge(new TeamChallenge(){ TeamId = teamChallengeJson.TeamId, ChallengeId = challenge.ChallengeId });
            return Ok(challenge.ChallengeId);
        }
    }
}
