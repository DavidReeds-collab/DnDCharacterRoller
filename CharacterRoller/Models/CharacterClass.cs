using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class Class
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Class")]
        public string Name { get; set; }
        public List<ClassFeature> classFeatures = new List<ClassFeature>();
        public List<Character> Characters = new List<Character>();
        public string AbilityScoreImprovements { get; set; }

        public Class()
        {
        }
    }
}
