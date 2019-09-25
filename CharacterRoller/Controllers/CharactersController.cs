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


    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static Races racesMain;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            character.characterRace = _context.Races.Where(r => r.Id == character.characterRaceId).FirstOrDefault();

            character.characterRace.raceFeatures = _context.RaceFeatures.Where(rf => rf.race == character.characterRace.Id).ToList();

            character.characterClass = _context.Classes.Where(c => c.Id == character.characterClassId).FirstOrDefault();

            character.characterClass.classFeatures = _context.ClassFeatures.Where(a => a.Class == character.characterClass.Id).ToList();

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewBag.races = FillRaceList();
            ViewBag.classes = FillClassList();

            return View();
        }

        public List<SelectListItem> FillRaceList()
        {
            var list = new List<SelectListItem>();

            var DataBaseLlist = _context.Races.ToList();

            foreach (var item in DataBaseLlist)
            {
                list.Add(new SelectListItem { Text = item.Id.ToString(), Value = item.Id.ToString() });
            }

            return list;
        }

        public List<SelectListItem> FillClassList()
        {
            var list = new List<SelectListItem>();

            var DataBaseLlist = _context.Classes.ToList();

            foreach (var item in DataBaseLlist)
            {
                list.Add(new SelectListItem { Text = item.Id.ToString(), Value = item.Id.ToString() });
            }

            return list;
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Level, characterClassId, characterRaceId")] Character character)
        {

            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Level,Experience")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
