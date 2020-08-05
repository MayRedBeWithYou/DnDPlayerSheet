using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public class CombatAction
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Atak okazyjny?")]
        public string OppurtunityAttack { get; set; }

        [Display(Name = "Akcja darmowa?")]
        public bool IsFree { get; set; }

        [Display(Name = "Akcja całorundowa?")]
        public bool IsFullRound { get; set; }
    }
}
