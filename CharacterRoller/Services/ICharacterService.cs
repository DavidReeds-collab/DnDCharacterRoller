using CharacterRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Services
{
    public interface ICharacterService
    {
        Task<Character> LoadCharacter(int id);
    }
}
