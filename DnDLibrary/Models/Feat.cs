using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public class Feat
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; }

        [Display(Name = "Wymagania")]
        public string Requirements { get; set; }

        [Display(Name = "Opis"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
