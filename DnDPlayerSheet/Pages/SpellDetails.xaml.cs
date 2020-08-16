using DnDPlayerSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpellDetails : ContentPage
    {
        public Spell Spell { get; }

        public SpellDetails(Spell spell)
        {
            Spell = spell;
            InitializeComponent();
            BindingContext = this;
        }
    }
}