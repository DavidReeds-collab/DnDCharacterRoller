using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterRoller.Data;
using CharacterRoller.Models;

namespace CharacterRoller.Services
{
    public class ChoiceServices : IChoiceResolverService
    {
        private readonly ApplicationDbContext _context;
        private ICharacterService _charService;
        public ChoiceServices(ApplicationDbContext context, ICharacterService charService)
        {
            _context = context;
            _charService = charService;
        }

        //Add's a resolved choice to the character in the database from a choicereciever.
        public async Task ChoiceResolver(int characterId, List<ChoiceReciever> choiceRecievers)
        {
            //Haalt character op zodat deze geupdate kan worden. 
            Character _character = await _charService.LoadCharacter(characterId);

            Choice classChoice = _context.Choices.Where(c => c.Id == choiceRecievers[0].choiceId).FirstOrDefault();

            switch (classChoice.Type)
            {
                case "Proficiency":
                    ProficiencyChoice characterProficiency = new ProficiencyChoice(classChoice, _character, choiceRecievers);
                    _character.CharacterProficiencyChoices.Add(characterProficiency);
                    _context.Choices.Add(characterProficiency);
                    _context.SaveChanges();
                    break;
                case "Feature":
                    FeatureChoice characterFeature = new FeatureChoice(classChoice, _character, choiceRecievers);
                    _character.CharacterFeatureChoices.Add(characterFeature);
                    _context.Choices.Add(characterFeature);
                    _context.SaveChanges();
                    break;
                default:
                    break;
            }
            _context.Update(_character);
            _context.SaveChanges();
        }
    }
}
