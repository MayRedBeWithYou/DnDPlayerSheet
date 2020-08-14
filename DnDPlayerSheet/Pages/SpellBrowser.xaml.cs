using DnDLibrary.Models;
using DnDPlayerSheet.Models;
using DnDPlayerSheet.XamlExtensions;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpellBrowser : ContentPage
    {
        private ObservableCollection<Spell> spells = new ObservableCollection<Spell>();

        
        public ObservableCollection<Spell> Spells
        {
            get => spells;
            set
            {
                spells = value;
                OnPropertyChanged("Spells");
            }
        }

        public SpellBrowser()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public async Task InitSpells()
        {
            var spells = await App.DataProvider.GetSpellsAsync();
            Spells = new ObservableCollection<Spell>(spells.OrderBy(x => x.Tier).ThenBy(x => x.Name));
            SpellListView.ItemsSource = Spells;
        }

        private void AddSpell(object sender, EventArgs e)
        {
            Spell spell = (Spell)((Button)sender).BindingContext;
            App.PlayerController.SelectedCharacter.AddSpell(spell);
            CrossToastPopUp.Current.ShowToastMessage("Dodano " + spell.Name + " do twoich zaklęć.");
        }

        private void SpellListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Spell spell = e.ItemData as Spell;
            CrossToastPopUp.Current.ShowToastMessage(spell.Name);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SpellListView.DataSource != null)
            {
                SpellListView.DataSource.Filter = FilterSpells;
                SpellListView.DataSource.RefreshFilter();
            }
        }

        private void RefreshFilter(object sender, EventArgs e)
        {
            if (SpellListView.DataSource != null)
            {
                SpellListView.DataSource.Filter = FilterSpells;
                SpellListView.DataSource.RefreshFilter();
            }
        }

        private bool FilterSpells(object obj)
        {
            var spell = obj as Spell;
            bool result = false;
            if (SearchBar == null || String.IsNullOrEmpty(SearchBar.Text))
                result = true;
            else
            {
                if (spell.Name.ToLower().Contains(SearchBar.Text.ToLower())) result = true;
                else result = false;
            }

            if (SchoolPicker.SelectedIndex == -1 || SchoolPicker.SelectedIndex == (int)spell.School) result &= true;
            else result = false;

            if (RolePicker.SelectedIndex == -1) result &= true;
            else
            {
                Role role = (Role)RolePicker.SelectedIndex;
                string text = Conversion.RoleShort(role).ToLower();
                if (spell.Level.ToLower().Contains(text)) result &= true;
                else result = false;
            }
            return result;
        }

        private void ResetSchool(object sender, EventArgs e)
        {
            SchoolPicker.SelectedIndex = -1;
        }

        private void ResetRole(object sender, EventArgs e)
        {
            RolePicker.SelectedIndex = -1;
        }
    }
}