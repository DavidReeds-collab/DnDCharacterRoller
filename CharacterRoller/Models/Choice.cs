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
    public interface IChoice
    {
        string Options { get; set; }
        int AllowedNumberOfOptions { get; set; }
    }

    public interface IProficiencyChoice : IChoice
    {
        string ChosenProficiencies { get; set; }
    }

    public interface IClassFeatureChoice : IChoice
    {
        string ChosenFeature { get; set; }
    }



    public class Choice
    {
        [Key]
        public string Id { get; set; }
        [NotMapped]
        public ClassFeature classFeature { get; set; }
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

    }


}
