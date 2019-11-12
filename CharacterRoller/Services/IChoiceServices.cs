using CharacterRoller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Services
{
    public interface IChoiceResolverService
    {
        Task ChoiceResolver(int characterId, List<ChoiceReciever> choiceRecievers);
    }
}
