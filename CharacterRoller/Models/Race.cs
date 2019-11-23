using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class Race
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Race")]
        public string Name { get; set; }
        public string AbilityScoreImprovements { get; set; }

        public List<Character> Characters = new List<Character>();

        public List<RaceFeature> raceFeatures = new List<RaceFeature>();

        public Race()
        {
        }
    }
}
