using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NationBuilder.Models;
using NationBuilder.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace NationBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // REMOVE THE DELETE WHEN WE WANT ACTUAL DATA PERSISTENCE
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var currentNation = _db.Nations.Include(n => n.ResourcesObj).Where(n => n.User == user).ToList();
            foreach(var nation in currentNation)
            {
                _db.Remove(nation);
            }
            _db.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Nation nation)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = _db.Users.FirstOrDefault(u => u.Id == userId);
            nation.User = user;
            _db.Nations.Add(nation);
            Resource resource = new Resource();
            resource.NationId = nation.NationId;
            _db.Resources.Add(resource);
            _db.SaveChanges();
            return RedirectToAction("Game");
        }

        public IActionResult Game()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser user = _db.Users.FirstOrDefault(u => u.Id == userId);
            Nation currentNation = _db.Nations.Include(n => n.ResourcesObj).FirstOrDefault(n => n.User == user);
            currentNation.Build();
            _db.Entry(currentNation).State = EntityState.Modified;
            _db.Entry(currentNation.ResourcesObj).State = EntityState.Modified;
            _db.SaveChanges();
            return View(currentNation);
        }
    }
}
