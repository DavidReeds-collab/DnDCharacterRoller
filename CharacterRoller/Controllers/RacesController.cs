using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharacterRoller.Data;
using CharacterRoller.Models;

namespace CharacterRoller.Controllers
{
    public class RacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Races
        public IActionResult Index()
        {
            

            return View(getRaces());
        }

        public List<Race> getRaces()
        {
            List<Race> races = new List<Race>();

            races = _context.Races.ToList();

            foreach (var race in races)
            {
                race.raceFeatures = _context.RaceFeatures.Where(R => R.race == race.Id).ToList();
            }

            return races;
        }

        private bool RaceExists(string id)
        {
            return _context.Races.Any(e => e.Id == id);
        }
    }
}
