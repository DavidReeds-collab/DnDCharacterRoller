using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharacterRoller.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CharacterRoller.Models.Character> Characters { get; set; }
        public DbSet<CharacterRoller.Models.Race> Races { get; set; }
        public DbSet<CharacterRoller.Models.Class> Classes { get; set; }
        public DbSet<CharacterRoller.Models.Skill> Skills { get; set; }
        public DbSet<CharacterRoller.Models.Ability> Abilities { get; set; }
        public DbSet<Dictionary<string, string>> RaceFeatures { get; set; }
        public DbSet<Dictionary<string, string>> ClassFeatures { get; set; }
    }
}
