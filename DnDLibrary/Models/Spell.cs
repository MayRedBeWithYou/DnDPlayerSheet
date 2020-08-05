using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public enum SpellSchool
    {
        [Display(Name = "Odrzucanie")]
        Abjuration,
        [Display(Name = "Przywołanie")]
        Conjuration,
        [Display(Name = "Poznanie")]
        Divination,
        [Display(Name = "Oczarowanie")]
        Enchantment,
        [Display(Name = "Wywoływanie")]
        Evocation,
        [Display(Name = "Iluzje")]
        Illusion,
        [Display(Name = "Nekromancja")]
        Necromancy,
        [Display(Name = "Przemiana")]
        Transmutation,
        [Display(Name = "Uniwersalne")]
        Universal
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

    public class Spell
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Szkoła")]
        public SpellSchool School { get; set; }

        [Display(Name = "Poziom zaklęcia")]
        public int Tier { get; set; }

        [Display(Name = "Poziom postaci")]
        public string Level { get; set; }

        [Display(Name = "Komponenty")]
        public string Components { get; set; }

        [Display(Name = "Czas rzucania")]
        public string CastTime { get; set; }

        [Display(Name = "Zasięg")]
        public string Range { get; set; }

        [Display(Name = "Cele/obszar"), DataType(DataType.MultilineText)]
        public string Target { get; set; }

        [Display(Name = "Czas trwania")]
        public string Duration { get; set; }

        [Display(Name = "Rzut obronny")]
        public string SavingThrow { get; set; }

        [Display(Name = "Odporność na czary")]
        public string SpellResistance { get; set; }

        [Display(Name = "Opis"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Komponent materialny"), DataType(DataType.MultilineText)]
        public string MaterialComponent { get; set; }
    }
}
