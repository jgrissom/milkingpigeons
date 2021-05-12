using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MilkingPigeons.Models;

namespace MilkingPigeons.Controllers
{
    public class APIController : Controller
    {
        // this controller depends on the NorthwindRepository
        private DataContext _dataContext;
        public APIController(DataContext db) => _dataContext = db;

        [HttpGet, Route("api/category")]
        // returns all categories
        public IEnumerable<Category> Get() => _dataContext.Categories.OrderBy(c => c.Name);
        [HttpGet, Route("api/category/{id}")]
        // returns specific category
        public Category Get(int id) => _dataContext.Categories.FirstOrDefault(c => c.CategoryId == id);
    }
}
