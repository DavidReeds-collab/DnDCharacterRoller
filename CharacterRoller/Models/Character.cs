using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace CharacterRoller.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, 20)]
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Proficiency { get { return (int)(1 + MathF.Ceiling((float)((double)this.Level / 4.0))); } }

        public string Proficiencies { get; set; } = "";

        public string Expertises { get; set; } = "";

        #region Ability Scores
        [NotMapped]
        public string AbilityScoreImprovements { get
            {
                if (this.characterRace != null && this.characterClass != null)
                {
                    return this.characterRace.AbilityScoreImprovements + "|" + this.characterClass.AbilityScoreImprovements;
                }
                else
                {
                    return "";
                }

            } }
        [NotMapped]
        public Dictionary<string, int> AbilityScoreList { get
            {
                return new Dictionary<string, int>() {
                    { "Strenght", this.Strenght},
                    { "Dexterity", this.Dexterity},
                    { "Constitution", this.Constitution},
                    { "Intelligence", this.Intelligence },
                    { "Wisdom", this.Wisdom },
                    { "Charisma", this.Charisma }
                };

            } }
        [Range(3,18)]
        [DisplayName("Strenght")]
        public int StrenghtBase { get; set; } = 10;
        [NotMapped]
        public int Strenght { get
            {
                return this.StrenghtBase + AbilityScoreImprovementCalculator("Strenght");
            } }
        [NotMapped]
        public int StrenghtBonus { get { return (int)Math.Floor((double)(this.Strenght - 10) / 2.0); }  }
        [Range(3, 18)]
        [DisplayName("Dexterity")]
        public int DexterityBase { get; set; } = 10;
        [NotMapped]
        public int Dexterity
        {
            get
            {
                return this.DexterityBase + AbilityScoreImprovementCalculator("Dexterity");
            }
        }
        [NotMapped]
        public int DexterityBonus { get { return (int)Math.Floor((double)(this.Dexterity - 10) / 2.0); } }
        [Range(3, 18)]
        [DisplayName("Constitution")]
        public int ConstitutionBase { get; set; } = 10;
        [NotMapped]
        public int Constitution
        {
            get
            {
                return this.ConstitutionBase + AbilityScoreImprovementCalculator("Constitution");
            }
        }
        [NotMapped]
        public int ConstitutionBonus { get { return (int)Math.Floor((double)(this.Constitution - 10) / 2.0); } }
        [Range(3, 18)]
        [DisplayName("Ingelligence")]
        public int IntelligenceBase { get; set; } = 10;
        [NotMapped]
        public int Intelligence
        {
            get
            {
                return this.IntelligenceBase + AbilityScoreImprovementCalculator("Intelligence");
            }
        }
        [NotMapped]
        public int IntelligenceBonus { get { return (int)Math.Floor((double)(this.Intelligence - 10) / 2.0); } }
        [Range(3, 18)]
        [DisplayName("Wisdom")]
        public int WisdomBase { get; set; } = 10;
        [NotMapped]
        public int Wisdom
        {
            get
            {
                return this.WisdomBase + AbilityScoreImprovementCalculator("Wisdom");
            }
        }
        [NotMapped]
        public int WisdomBonus { get { return (int)Math.Floor((double)(this.Wisdom - 10) / 2.0); } }
        [Range(3, 18)][DisplayName("Charisma")]
        public int CharismaBase { get; set; } = 10;
        [NotMapped]
        public int Charisma
        {
            get
            {
                return this.CharismaBase + AbilityScoreImprovementCalculator("Charisma");
            }
        }
        [NotMapped]
        public int CharismaBonus { get { return (int)Math.Floor((double)(this.Charisma - 10) / 2.0); } }
        #endregion

        #region Skills
        [NotMapped]
        public Dictionary<string, int> SkillList
        {
            get
            {
                return new Dictionary<string, int>() {
                    { "Acrobatics", this.AcrobaticsModifier},
                    { "Animal Handling", this.AnimalHandlingModifier},
                    { "Arcana", this.ArcanaModifier},
                    { "Athletics", this.AthleticsModifier},
                    { "Deception", this.DeceptionModifier},
                    { "History", this.HistoryModifier},
                    { "Insight", this.InsightModifier},
                    { "Intimidation", this.IntimidationModifier},
                    { "Investigation", this.InvestigationModifier},
                    { "Medicine", this.MedicineModifier},
                    { "Nature", this.NatureModifier},
                    { "Perception", this.PerceptionModifier},
                    { "Performance", this.PerformanceModifier},
                    { "Persuasion", this.PersuasionModifier},
                    { "Religion", this.ReligionModifier},
                    { "Sleight of hand", this.SleightOfHandModifier},
                    { "Stealth", this.StealthModifier},
                    { "Survival", this.SurvivalModifier}
                };

            }
        }
        [NotMapped]
        public int AcrobaticsModifier
        {
            get
            {
                int returnValue = 0 + this.DexterityBonus;
                if (this.Proficiencies.Contains("Acrobatics"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Acrobatics"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int AnimalHandlingModifier
        {
            get
            {
                int returnValue = 0 + this.WisdomBonus;
                if (this.Proficiencies.Contains("AnimalHandling"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("AnimalHandling"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int ArcanaModifier
        {
            get
            {
                int returnValue = 0 + this.IntelligenceBonus;
                if (this.Proficiencies.Contains("Arcana"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Arcana"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int AthleticsModifier { get {
                int returnValue = 0 + this.StrenghtBonus;
                if (this.Proficiencies.Contains("Athletics"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Athletics"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            } }
        [NotMapped]
        public int DeceptionModifier
        {
            get
            {
                int returnValue = 0 + this.CharismaBonus;
                if (this.Proficiencies.Contains("Deception"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Deception"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int HistoryModifier
        {
            get
            {
                int returnValue = 0 + this.IntelligenceBonus;
                if (this.Proficiencies.Contains("History"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("History"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int InsightModifier
        {
            get
            {
                int returnValue = 0 + this.WisdomBonus;
                if (this.Proficiencies.Contains("Insight"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Insight"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int IntimidationModifier
        {
            get
            {
                int returnValue = 0 + this.CharismaBonus;
                if (this.Proficiencies.Contains("Intimidation"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Intimidation"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int InvestigationModifier
        {
            get
            {
                int returnValue = 0 + this.IntelligenceBonus;
                if (this.Proficiencies.Contains("Investigation"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Investigation"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int MedicineModifier
        {
            get
            {
                int returnValue = 0 + this.WisdomBonus;
                if (this.Proficiencies.Contains("Medicine"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Medicine"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int NatureModifier
        {
            get
            {
                int returnValue = 0 + this.IntelligenceBonus;
                if (this.Proficiencies.Contains("Nature"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Nature"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int PerceptionModifier
        {
            get
            {
                int returnValue = 0 + this.WisdomBonus;
                if (this.Proficiencies.Contains("Perception"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Perception"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int PerformanceModifier
        {
            get
            {
                int returnValue = 0 + this.CharismaBonus;
                if (this.Proficiencies.Contains("Performance"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Performance"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int PersuasionModifier
        {
            get
            {
                int returnValue = 0 + this.CharismaBonus;
                if (this.Proficiencies.Contains("Persuasion"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Persuasion"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int ReligionModifier
        {
            get
            {
                int returnValue = 0 + this.IntelligenceBonus;
                if (this.Proficiencies.Contains("Religion"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Religion"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int SleightOfHandModifier
        {
            get
            {
                int returnValue = 0 + this.DexterityBonus;
                if (this.Proficiencies.Contains("SleightOfHand"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("SleightOfHand"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int StealthModifier
        {
            get
            {
                int returnValue = 0 + this.DexterityBonus;
                if (this.Proficiencies.Contains("Stealth"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Stealth"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }
        [NotMapped]
        public int SurvivalModifier
        {
            get
            {
                int returnValue = 0 + this.WisdomBonus;
                if (this.Proficiencies.Contains("Survival"))
                {
                    returnValue += this.Proficiency;
                }
                if (this.Expertises.Contains("Survival"))
                {
                    returnValue += this.Proficiency;
                }
                return returnValue;
            }
        }



        #endregion

        public Race characterRace { get; set; }
        [Display(Name = "Race")]
        public string characterRaceId { get; set; }

        public Class characterClass { get; set; }
        [Display(Name = "Class")]
        public string characterClassId { get; set; }

        private int AbilityScoreImprovementCalculator(string AbilityScore)
        {
            int returnInt = 0;

            List<string> splitAbilityScoreImprovements = new List<string>();

            splitAbilityScoreImprovements = this.AbilityScoreImprovements.Split('|').Where(a => a.Contains(AbilityScore)).ToList();

            foreach (var item in splitAbilityScoreImprovements)
            {
                string bonus = new String(item.Where(Char.IsDigit).ToArray());
                returnInt += int.Parse(bonus);

            }

            return returnInt;
        }

        public Character()
        {


            

        }

        
    }
   


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

    public class Races
    {
        public List<SelectListItem> races { get; set; }

        public string id { get; set; }

        public string Race { get; set; }
    }

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

    public class ClassFeature
    {
        public string classFeatureId { get; set; }
        public int Level { get; set; }
        public string choiceId { get; set; }
        public Choice Choice { get; set; } = null;


        public string Class { get; set; }
        public string Feature { get; set; }
    }   
}
