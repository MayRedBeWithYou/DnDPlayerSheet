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
    public class EnumDisplayNameConverter : EnumConverter
    {
        public EnumDisplayNameConverter(Type type)
            : base(type)
        {
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    if (fi != null)
                    {
                        var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);
                        return ((attributes.Length > 0) && (!String.IsNullOrEmpty(attributes[0].Name))) ? attributes[0].Name : value.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    [TypeConverter(typeof(EnumDisplayNameConverter))]
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

    [TypeConverter(typeof(EnumDisplayNameConverter))]
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

        public int Inteligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }
    }
}
