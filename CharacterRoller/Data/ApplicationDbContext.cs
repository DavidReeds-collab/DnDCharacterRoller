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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Races
            #region Human
            modelBuilder.Entity<Race>().HasData(new Race()
            {
                Id = "human",
                Name = "Human",
                AbilityScoreImprovements = "Strenght_1_Racial|Dexterity_1_Racial|Constitution_1_Racial|Intelligence_1_Racial|Wisdom_1_Racial|Charisma_1_Racial",
            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "1",
                raceFeatureName = "Abilities",
                Feature = "Your Ability Scores each increase by 1.",
                race = "human"

            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "2",
                raceFeatureName = "Age",
                Feature = "Humans reach Adulthood in their late teens and live less than a century.",
                race = "human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "3",
                raceFeatureName = "Alignment",
                Feature = "Humans tend toward no particular Alignment. The best and the worst are found among them.",
                race = "human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "4",
                raceFeatureName = "Size",
                Feature = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.",
                race = "human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "5",
                raceFeatureName = "Speed",
                Feature = "Your base walking speed is 30 feet.",
                race = "human"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "6",
                raceFeatureName = "Languages",
                Feature = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with," +
                " including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions," +
                " Dwarvish Military phrases, and so on.",
                race = "human"

            });
            #endregion
            #region Human(variant)
            modelBuilder.Entity<Race>().HasData(new Race()
            {
                Id = "humanVariant",
                Name = "Human (Variant)"
            });

            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "7",
                raceFeatureName = "Abilities",
                Feature = "Two different ability scores of your choice increase by 1.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "8",
                raceFeatureName = "Skills",
                Feature = "You gain proficiency in one skill of your choice.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "9",
                raceFeatureName = "Feat",
                Feature = "You gain one Feat of your choice.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "10",
                raceFeatureName = "Age",
                Feature = "Humans reach Adulthood in their late teens and live less than a century.",
                race = "humanVariant"
            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "11",
                raceFeatureName = "Alignment",
                Feature = "Humans tend toward no particular Alignment. The best and the worst are found among them.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "12",
                raceFeatureName = "Size",
                Feature = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureId = "13",
                raceFeatureName = "Speed",
                Feature = "Your base walking speed is 30 feet.",
                race = "humanVariant"

            });
            modelBuilder.Entity<RaceFeature>().HasData(new RaceFeature()
            {
                raceFeatureName = "Languages",
                Feature = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with," +
                " including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions," +
                " Dwarvish Military phrases, and so on.",
                race = "humanVariant"

            });
            #endregion
            #endregion
            #region Classes
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "barbarian",
                Name = "Barbarian"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "bard",
                Name = "Bard"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "cleric",
                Name = "Cleric"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "druid",
                Name = "Druid"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "fighter",
                Name = "Fighter"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "monk",
                Name = "Monk"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "paladin",
                Name = "Paladin"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "ranger",
                Name = "Ranger"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "rogue",
                Name = "Rogue"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "sorcerer",
                Name = "Sorcerer"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "warlock",
                Name = "Warlock"
            });
            modelBuilder.Entity<Class>().HasData(new Class()
            {
                Id = "wizard",
                Name = "Wizard"
            });
            #endregion



        }




        public DbSet<CharacterRoller.Models.Character> Characters { get; set; }
        public DbSet<CharacterRoller.Models.Race> Races { get; set; }
        public DbSet<CharacterRoller.Models.Class> Classes { get; set; }
        public DbSet<CharacterRoller.Models.RaceFeature> RaceFeatures { get; set; }
        public DbSet<CharacterRoller.Models.ClassFeature> ClassFeatures { get; set; }

    }
}
