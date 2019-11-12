using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class Choice
    {
        [Key]
        public string Id { get; set; }
        [NotMapped]
        public ClassFeature classFeature { get; set; }

        public string Type { get; set; }

        [NotMapped]
        public List<string> OptionsList {
            get
            {
                List<string> returnList = new List<string>();

                returnList = Options.Split(',').ToList();

                return returnList;
            } }
        public string Options { get; set; }
        [DisplayName("Allowed number of options")]
        public int AllowedNumberOfOptions { get; set; }

        public Choice(List<string> options, int allowedNumberOfOptions)
        {
            StringBuilder stringbuilder = new StringBuilder();
            foreach (string  option in options)
            {

                stringbuilder.Append($"{option},");

                stringbuilder.Remove(stringbuilder.Length, 1);
            }
            this.Options = stringbuilder.ToString();
            this.AllowedNumberOfOptions = allowedNumberOfOptions;
        }
        public Choice()
        {
        }
    }

    public class ProficiencyChoice : Choice
    {
        public int CharacterId { get; set; }

        [NotMapped]
        public Character Character { get; set; }

        public string ChosenProficiencies { get; set; }
        [NotMapped]
        public List<string> ChosenProficienciesList
        {
            get
            {
                List<string> returnList = new List<string>();

                returnList = Options.Split(',').ToList();

                return returnList;
            }
        }

        public ProficiencyChoice()
        {

        }

        public ProficiencyChoice(Choice choice, Character character)
        {
            this.Id = choice.Id + character.Id;
            this.Type = "Proficiency";
            this.AllowedNumberOfOptions = choice.AllowedNumberOfOptions;
            this.Character = character;
            this.CharacterId = character.Id;
            this.classFeature = choice.classFeature;
            this.Options = choice.Options;
        }

        public ProficiencyChoice(Choice choice, Character character, List<ChoiceReciever> choiceRecievers)
        {
            this.Id = choice.Id + character.Id;
            this.Type = "Feature";
            this.AllowedNumberOfOptions = choice.AllowedNumberOfOptions;
            this.Character = character;
            this.CharacterId = character.Id;
            this.classFeature = choice.classFeature;
            this.Options = choice.Options;
            this.ChosenProficiencies = "";

            foreach (ChoiceReciever chosenOption in choiceRecievers)
            {
                if (chosenOption.selected)
                {
                    this.ChosenProficiencies += (chosenOption.name + ",");
                }

            }

            if (this.ChosenProficiencies.Last() == ',')
            {
                this.ChosenProficiencies.Remove(ChosenProficiencies.Length - 1);
            }

        }
    }

    public class FeatureChoice : Choice
    {
        public int CharacterId { get; set; }

        [NotMapped]
        public Character Character { get; set; }

        public string ChosenFeatures { get; set; }
        [NotMapped]
        public List<string> ChosenFeaturesList
        {
            get
            {
                List<string> returnList = new List<string>();

                returnList = Options.Split(',').ToList();

                return returnList;
            }
        }

        public FeatureChoice()
        {

        }

        public FeatureChoice(Choice choice, Character character)
        {
            this.Id = choice.Id + character.Id;
            this.Type = "Feature";
            this.AllowedNumberOfOptions = choice.AllowedNumberOfOptions;
            this.Character = character;
            this.CharacterId = character.Id;
            this.classFeature = choice.classFeature;
            this.Options = choice.Options;
        }

        public FeatureChoice(Choice choice, Character character, List<ChoiceReciever> choiceRecievers)
        {
            this.Id = choice.Id + character.Id;
            this.Type = "Feature";
            this.AllowedNumberOfOptions = choice.AllowedNumberOfOptions;
            this.Character = character;
            this.CharacterId = character.Id;
            this.classFeature = choice.classFeature;
            this.Options = choice.Options;
            this.ChosenFeatures = "";

            foreach (ChoiceReciever chosenOption in choiceRecievers)
            {
                if (chosenOption.selected)
                {
                    this.ChosenFeatures += (chosenOption.name + ",");
                }
                
            }

            if (this.ChosenFeatures.Last() == ',')
            {
                this.ChosenFeatures.Remove(ChosenFeatures.Length - 1);
            }
            
        }

    }

    public class ChoiceViewModel
    {
        public List<Choice> Choices { get; set; }
        public Character Character { get; set; }
    }

    public class ChoiceReciever
    {
        public string choiceId { get; set; }
        public string name { get; set; }
        public bool selected { get; set; }
    }


}
