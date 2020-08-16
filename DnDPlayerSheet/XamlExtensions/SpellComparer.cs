using DnDPlayerSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDPlayerSheet.XamlExtensions
{
    public class SpellComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            Spell a = x as Spell;
            Spell b = y as Spell;
            if (a.Tier > b.Tier) return 1;
            else if (a.Tier < b.Tier) return -1;
            else
            {
                return a.Name.CompareTo(b.Name);
            }
        }
    }
}
