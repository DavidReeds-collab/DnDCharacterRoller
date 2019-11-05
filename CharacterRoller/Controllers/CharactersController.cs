using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CharacterRoller.Data;
using CharacterRoller.Models;
using CharacterRoller.Services;

namespace CharacterRoller.Controllers
{


    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static Races racesMain;
        private ICharacterService _charService;

        public CharactersController(ApplicationDbContext context, ICharacterService charService)
        {
            _context = context;
            _charService = charService;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Character character = await _charService.LoadCharacter(id);

            if (character == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("Name,Level,StrenghtBase,DexterityBase,ConstitutionBase,IntelligenceBase,WisdomBase,CharismaBase, characterClassId, characterRaceId")] Character character)
        {

            List<Choice> choices = new List<Choice>();

            if (ModelState.IsValid)
            {
                _context.Add(character);

                await _context.SaveChangesAsync();

                Character _character = await _charService.LoadCharacter(character.Id);

                choices = await GetChoices(character);

                if (choices.Count == 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (choices.Count != 0)
                {                    
                    return View("Choices", choices);
                }
            }



            return View(character);
        }

        private async Task<List<Choice>> GetChoices(Character character)
        {
            List<Choice> choices = new List<Choice>();

            foreach (ClassFeature feature in character.characterClass.classFeatures)
            {
                if (string.IsNullOrEmpty(feature.choiceId) || feature.Level > character.Level)
                {
                    continue;
                }

                feature.Choice = _context.Choices.Where(c => c.Id == feature.choiceId).FirstOrDefault();

                feature.Choice.classFeature = feature;

                choices.Add(feature.Choice);
            }

            return choices;
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
