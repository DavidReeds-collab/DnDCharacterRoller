using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class Choice
    {
        [Key]
        public string Id { get; set; }
        public bool resolved { get; set; } 
        public List<string> OptionsList {
            get
            {
                List<string> returnList = new List<string>();

                returnList = Options.Split(',').ToList();

                return returnList;
            } }
        public string Options { get; set; }
        public int AllowedNumberOfOptions { get; set; }
        public ChoiceDestinations Destination { get; set; }
        public List<string> ChosenOptionsList
        {
            get
            {
                List<string> returnList = new List<string>();

                returnList = ChosenOptions.Split(',').ToList();

                return returnList;
            }
        }
        public string ChosenOptions { get; set; }

        public Choice(List<string> options, int allowedNumberOfOptions, ChoiceDestinations destination)
        {
            StringBuilder stringbuilder = new StringBuilder();
            foreach (string  option in options)
            {

                stringbuilder.Append($"{option},");

                stringbuilder.Remove(stringbuilder.Length, 1);
            }
            this.Options = stringbuilder.ToString();
            this.AllowedNumberOfOptions = allowedNumberOfOptions;
            this.Destination = destination;
        }
        public Choice()
        {
        }
    }

    public enum ChoiceDestinations
    {
        Proficiency,
        Feature
    }
}
