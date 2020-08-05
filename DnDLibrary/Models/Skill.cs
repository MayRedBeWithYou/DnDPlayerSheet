using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DnDPlayerSheet.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Atrybut kluczowy")]
        public string KeyAttribute { get; set; }
    }
}
