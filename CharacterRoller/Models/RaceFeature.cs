using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class RaceFeature
    {
        [Display(Name = "Racial Feature")]
        public string raceFeatureName { get; set; }
        [Key]
        public string raceFeatureId
        {
            get; set;
        }
        public string race { get; set; }
        public string Feature { get; set; }


        public RaceFeature()
        {
            raceFeatureId = this.race + this.raceFeatureName;
        }
    }
}
