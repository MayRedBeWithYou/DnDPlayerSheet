using DnDPlayerSheet.Models;
using Plugin.Toast;
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
    public partial class SpellsPage : ContentPage
    {
        public SpellsPage()
        {
            InitializeComponent();
        }

        private void RemoveSpell(object sender, EventArgs e)
        {
            Spell spell = (Spell)((Button)sender).BindingContext;
            App.PlayerController.SelectedCharacter.RemoveSpell(spell);
            CrossToastPopUp.Current.ShowToastMessage($"Usunięto {spell.Name} z twoich zaklęć.");
        }

        private async void SeeAllSpells(object sender, EventArgs e)
        {
            SpellBrowser browser = new SpellBrowser();
            await browser.InitSpells();
            await Navigation.PushModalAsync(browser);
        }

        private void SpellTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Spell spell = e.ItemData as Spell;
            if (spell is null) return;
            Navigation.PushModalAsync(new SpellDetails(spell));
        }
    }
}