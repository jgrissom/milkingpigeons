using System.Data.Common;
using System;
using Microsoft.AspNetCore.Mvc;
using MilkingPigeons.Models;
using System.Linq;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dataContext;
        public HomeController(DataContext db) => _dataContext = db;
        public ActionResult Index() => View();
        public ActionResult Team() => View(_dataContext.Teams.OrderBy(t => t.Name));
    }
}
