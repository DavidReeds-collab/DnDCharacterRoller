using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterRoller.Models
{
    public class Races
    {
        public List<SelectListItem> races { get; set; }

        public string id { get; set; }

        public string Race { get; set; }
    }
}
