using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace CharacterRoller.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Proficiency { get { return (int)MathF.Round(this.Level / 4) + 1; } }

        #region Ability Scores
        public Ability Strength { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Constitution { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Wisdom { get; set; }
        public Ability Charisma { get; set; }
        #endregion

        #region Skills
        public Skill Acrobatics { get; set; }
        public Skill animalHandling { get; set; }
        public Skill Arcana { get; set; }
        public Skill Athletics { get; set; }
        public Skill Deception { get; set; }
        public Skill History { get; set; }
        public Skill Insight { get; set; }
        public Skill Intimidation { get; set; }
        public Skill Investigation { get; set; }
        public Skill Medicine { get; set; }
        public Skill Nature { get; set; }
        public Skill Perception { get; set; }
        public Skill Performance { get; set; }
        public Skill Persuasion { get; set; }
        public Skill Religion { get; set; }
        public Skill sleightOfHand { get; set; }
        public Skill Stealth { get; set; }
        public Skill Suvival { get; set; }
        [NotMapped]
        public List<Skill> skills
        {
            get
            {
                Type character = this.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(character.GetProperties());

                List<Skill> returnlist = new List<Skill>();

                returnlist.Add(this.Acrobatics);
                returnlist.Add(this.animalHandling);
                returnlist.Add(this.Arcana);
                returnlist.Add(this.Athletics);
                returnlist.Add(this.Deception);
                returnlist.Add(this.History);
                returnlist.Add(this.Insight);
                returnlist.Add(this.Intimidation);
                returnlist.Add(this.Investigation);
                returnlist.Add(this.Medicine);
                returnlist.Add(this.Nature);
                returnlist.Add(this.Perception);
                returnlist.Add(this.Performance);
                returnlist.Add(this.Persuasion);
                returnlist.Add(this.Religion);
                returnlist.Add(this.sleightOfHand);
                returnlist.Add(this.Stealth);
                returnlist.Add(this.Suvival);
                return returnlist;
            }
        }
        #endregion

        public Race characterRace { get; set; }
        [Display(Name = "Race")]
        public string characterRaceId { get; set; }

        public Class characterClass { get; set; }
        [Display(Name = "Class")]
        public string characterClassId { get; set; }
    }

    public class Race
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Race")]
        public string Name { get; set; }
        public int StrenghtImprovement { get; set; } = 0;
        public int DexterityImprovement { get; set; } = 0;
        public int ConstitutionImprovement { get; set; } = 0;
        public int IntelligenceImprovement { get; set; } = 0;
        public int WisdomImprovement { get; set; } = 0;
        public int CharismaImprovement { get; set; } = 0;

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
        public List<Dictionary<string, int>> abilityScoreImprovements = new List<Dictionary<string, int>>();
        public List<ClassFeature> classFeatures = new List<ClassFeature>();
        public List<Character> Characters = new List<Character>();

        public Class()
        {
        }
    }

    public class ClassFeature
    {
        public string classFeatureId { get; set; }
        public int Level { get; set; }
        public bool choice { get; set; }

        public string Class { get; set; }
        public string Feature { get; set; }
    }

    public class Ability
    {
        
        public string Id { get; set; }
        public bool Proficient { get; internal set;  }
        private int baseValue;
            
        public int BaseValue { get { return baseValue; } internal set { baseValue = value; } }

        public int Value { get
            {
                int returnValue = baseValue;
                if (this.Proficient)
                {
                    returnValue += this.parentCharacter.Proficiency;
                }
                //foreach (KeyValuePair<string, int> improvement in this.parentCharacter.race.race.abilityScoreImprovements)
                //{
                //    if (improvement.Key == this.ToString())
                //    {
                //        returnValue += improvement.Value;
                //    }
                //}

                foreach (Dictionary<string, int> abilityScoreImprovement in this.parentCharacter.characterClass.abilityScoreImprovements)
                {
                    foreach (KeyValuePair<string, int> improvement in abilityScoreImprovement)
                    {
                        if (improvement.Key == this.ToString())
                        {
                            returnValue += improvement.Value;
                        }
                    }
                }

                return returnValue;
            } }

        public int Bonus { get { return (int)MathF.Floor((this.Value - 10) / 2); } }
        private Character parentCharacter;
        public int parentCharacterId { get { return this.parentCharacter.Id; } internal set { parentCharacterId = value; } }
        public Ability()
        {
            this.Id = this.ToString();
        }

        public Ability(Character character, int value, bool proficiency)
        {
            this.baseValue = value;
            this.Proficient = proficiency;
            this.parentCharacter = character;
            this.Id = this.ToString();
            this.parentCharacterId = parentCharacter.Id;
        }
    }

    public class Skill
    {
        [Key]
        public string Id { get; set; }
        private Character parentCharacter;
        public int parentCharacterId { get { return this.parentCharacter.Id; } internal set { parentCharacterId = value; } }
        public bool Proficient { get; set; } = false;
        public bool Expertise { get; set; } = false;

        public Ability parentAbility { get; set; }

        public int value {get
         {
                int returnValue = this.parentAbility.Bonus;
                if (this.Proficient)
                {
                    returnValue += parentCharacter.Proficiency;
                }

                return returnValue;
        } }

        public Skill()
        {

        }

        public Skill(Character character)
        {
            this.parentCharacter = character;
            this.parentCharacterId = parentCharacter.Id;

            switch (this.ToString())
            {
                case "Acrobatics":
                    this.parentAbility = this.parentCharacter.Dexterity;
                    break;
                case "animalHandling":
                    this.parentAbility = this.parentCharacter.Wisdom;
                    break;
                case "Arcana":
                    this.parentAbility = this.parentCharacter.Intelligence;
                    break;
                case "Athletics":
                    this.parentAbility = this.parentCharacter.Strength;
                    break;
                case "Deception":
                    this.parentAbility = this.parentCharacter.Charisma;
                    break;
                case "History":
                    this.parentAbility = this.parentCharacter.Intelligence;
                    break;
                case "Insight":
                    this.parentAbility = this.parentCharacter.Wisdom;
                    break;
                case "Intimidation":
                    this.parentAbility = this.parentCharacter.Charisma;
                    break;
                case "Investigation":
                    this.parentAbility = this.parentCharacter.Intelligence;
                    break;
                case "Medicine":
                    this.parentAbility = this.parentCharacter.Wisdom;
                    break;
                case "Nature":
                    this.parentAbility = this.parentCharacter.Intelligence;
                    break;
                case "Perception":
                    this.parentAbility = this.parentCharacter.Wisdom;
                    break;
                case "Performance":
                    this.parentAbility = this.parentCharacter.Charisma;
                    break;
                case "Persuasion":
                    this.parentAbility = this.parentCharacter.Charisma;
                    break;
                case "Religion":
                    this.parentAbility = this.parentCharacter.Intelligence;
                    break;
                case "sleightOfHand":
                    this.parentAbility = this.parentCharacter.Dexterity;
                    break;
                case "Stealth":
                    this.parentAbility = this.parentCharacter.Dexterity;
                    break;
                case "Survival":
                    this.parentAbility = this.parentCharacter.Dexterity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.Id = this.parentCharacter.Id + this.ToString();
        }
    }
}
