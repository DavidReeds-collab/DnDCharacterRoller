using System;
using System.Collections.Generic;
using System.Text;
using CharacterRoller.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Races
            #region Human
            modelBuilder.Entity<Race>().HasData(new Race()
            {
                Id = "Human",
                StrenghtImprovement = 1,
                DexterityImprovement = 1,
                ConstitutionImprovement = 1,
                WisdomImprovement = 1,
                IntelligenceImprovement = 1,
                CharismaImprovement = 1
            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanAbilities",
                Feature = "Your Ability Scores each increase by 1.",
                race = "Human"

            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanAge",
                Feature = "Humans reach Adulthood in their late teens and live less than a century.",
                race = "Human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanAlignment",
                Feature = "Humans tend toward no particular Alignment. The best and the worst are found among them.",
                race = "Human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanSize",
                Feature = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.",
                race = "Human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanSpeed",
                Feature = "Your base walking speed is 30 feet.",
                race = "Human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "HumanLanguages",
                Feature = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with," +
                " including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions," +
                " Dwarvish Military phrases, and so on.",
                race = "Human"

            });
            #endregion
            #region Human(variant)
            modelBuilder.Entity<Race>().HasData(new Race()
            {
                Id = "Human(variant)",
            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Abilities",
                Feature = "Two different ability scores of your choice increase by 1.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Skills",
                Feature = "You gain proficiency in one skill of your choice.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Feat",
                Feature = "You gain one Feat of your choice.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Age",
                Feature = "Humans reach Adulthood in their late teens and live less than a century.",
                race = "Human(variant)"
            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Alignment",
                Feature = "Humans tend toward no particular Alignment. The best and the worst are found among them.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Size",
                Feature = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Speed",
                Feature = "Your base walking speed is 30 feet.",
                race = "Human(variant)"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "Human(variant)Languages",
                Feature = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with," +
                " including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions," +
                " Dwarvish Military phrases, and so on.",
                race = "Human(variant)"

            });
            #endregion
            #endregion



        }




        public DbSet<CharacterRoller.Models.Character> Characters { get; set; }
        public DbSet<CharacterRoller.Models.Race> Races { get; set; }
        public DbSet<CharacterRoller.Models.Class> Classes { get; set; }
        public DbSet<CharacterRoller.Models.Skill> Skills { get; set; }
        public DbSet<CharacterRoller.Models.Ability> Abilities { get; set; }
        public DbSet<CharacterRoller.Models.RaceFeature> RaceFeatures { get; set; }
        public DbSet<CharacterRoller.Models.ClassFeature> ClassFeatures { get; set; }

    }
}
