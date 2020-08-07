using DnDPlayerSheet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text;

namespace DnDLibrary.Models
{
    public enum Role
    {
        [Display(Name = "Barbarzyńca")]
        Barbarian,
        [Display(Name = "Bard")]
        Bard,
        [Display(Name = "Kapłan")]
        Cleric,
        [Display(Name = "Druid")]
        Druid,
        [Display(Name = "Wojownik")]
        Fighter,
        [Display(Name = "Mnich")]
        Monk,
        [Display(Name = "Paladyn")]
        Paladin,
        [Display(Name = "Tropiciel")]
        Ranger,
        [Display(Name = "Łotrzyk")]
        Rogue,
        [Display(Name = "Zaklinacz")]
        Sorcerer,
        [Display(Name = "Czarodziej")]
        Wizard
    }

    public enum Alignment
    {
        [Display(Name = "Praworządny dobry")]
        LawfulGood,
        [Display(Name = "Neutralny dobry")]
        NeutralGood,
        [Display(Name = "Chaotyczny dobry")]
        ChaoticGood,
        [Display(Name = "Praworządny neutralny")]
        LawfulNeutral,
        [Display(Name = "Neutralny")]
        TrueNeutral,
        [Display(Name = "Chaotyczny neutralny")]
        ChaoticNeutral,
        [Display(Name = "Praworządny zły")]
        LawfulEvil,
        [Display(Name = "Neutralny zły")]
        NeutralEvil,
        [Display(Name = "Chaotyczny zły")]
        ChaoticEvil,
    }

    public struct ClassLevel
    {
        public Role Class { get; set; }

        public int Level { get; set; }
    }

    public class Character
    {
        public string Name { get; set; }

        public List<ClassLevel> Classes { get; set; }

        public Alignment Alignment { get; set; }

        public int MaxPW { get; set; }

        public int CurrentPW { get; set; }

        public int KP { get; set; }

        public int Touch { get; set; }

        public int Unprepared { get; set; }

        public int Speed { get; set; }

        public string Race { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }
    }
}
