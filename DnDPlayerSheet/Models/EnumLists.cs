using DnDLibrary.Models;
using DnDPlayerSheet.XamlExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public static class EnumLists
    {
        public static List<string> Alignments { get; } = Enum.GetValues(typeof(Alignment))
                                                             .OfType<Alignment>()
                                                             .Select(x => EnumToStringConverter.GetDescription(x))
                                                             .ToList();

        public static List<string> Schools { get; } = Enum.GetValues(typeof(SpellSchool))
                .OfType<SpellSchool>()
                .Select(x => EnumToStringConverter.GetDescription(x))
                .ToList();

        public static List<string> Roles { get; } = Enum.GetValues(typeof(Role))
                .OfType<Role>()
                .Select(x => EnumToStringConverter.GetDescription(x))
                .ToList();

    }
}
