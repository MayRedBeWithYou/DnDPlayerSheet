﻿using DnDPlayerSheet.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Text;

namespace DnDLibrary.Models
{
    public static class Conversion
    {
        public static string RoleShort(Role role)
        {
            switch (role)
            {
                case Role.Barbarian:
                    return "Brb";
                case Role.Bard:
                    return "Brd";
                case Role.Cleric:
                    return "Kap";
                case Role.Druid:
                    return "Drd";
                case Role.Paladin:
                    return "Pal";
                case Role.Ranger:
                    return "Trp";
                case Role.Sorcerer:
                case Role.Wizard:
                    return "Cza/Zak";
            }
            return "";
        }
    }

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
}
