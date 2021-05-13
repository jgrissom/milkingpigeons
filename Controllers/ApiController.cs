using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MilkingPigeons.Models;

namespace MilkingPigeons.Controllers
{
    public class APIController : Controller
    {
        // this controller depends on the DataRepository
        private DataContext _dataContext;
        public APIController(DataContext db) => _dataContext = db;

        // returns all categories (with at least 1 chalenge)
        [HttpGet, Route("api/category")]
        public IEnumerable<CategoryJson> GetCategories() => _dataContext.Categories.Where(c => c.Challenges.Count > 0).Select(c => new CategoryJson{Id = c.CategoryId, Name = c.Name}).OrderBy(c => c.Name);
        // returns all challenges based on Active T/F
        [HttpGet, Route("api/challenge/active/{active}")]
        public IEnumerable<ChallengeJson> GetActiveChallenges(bool active) => _dataContext.Challenges.Where(c => c.Active == active).Select(c => new ChallengeJson{Id = c.ChallengeId, Name = c.Name, CatId = c.CategoryId}).OrderBy(c => c.Name);
    }
}
