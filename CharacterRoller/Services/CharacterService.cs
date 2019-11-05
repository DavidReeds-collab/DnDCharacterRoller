using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterRoller.Data;
using CharacterRoller.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterRoller.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ApplicationDbContext _context;
        public CharacterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Character> LoadCharacter(int id)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);

            character.characterRace = _context.Races.Where(r => r.Id == character.characterRaceId).FirstOrDefault();

            character.characterRace.raceFeatures = _context.RaceFeatures.Where(rf => rf.race == character.characterRace.Id).ToList();

            character.characterClass = _context.Classes.Where(c => c.Id == character.characterClassId).FirstOrDefault();

            character.characterClass.classFeatures = _context.ClassFeatures.Where(a => a.Class == character.characterClass.Id).ToList();

            character.CharacterFeatureChoices = _context.featureChoices.Where(fc => fc.CharacterId == character.Id).ToList();

            character.CharacterProficiencyChoices = _context.proficiencyChoices.Where(pc => pc.CharacterId == character.Id).ToList();

            return character;
        }
    }
}
