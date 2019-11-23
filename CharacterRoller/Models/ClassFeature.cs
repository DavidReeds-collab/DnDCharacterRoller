using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class ClassFeature
    {
        public string classFeatureId { get; set; }
        public int Level { get; set; }
        public string choiceId { get; set; }
        public Choice Choice { get; set; } = null;
        public string Name { get; set; }

        public string Class { get; set; }
        public string Feature { get; set; }
    }
}
