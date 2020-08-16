using DnDLibrary.Models;
using DnDPlayerSheet.Controllers;
using DnDPlayerSheet.XamlExtensions;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {       

        public OverviewPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void GoToEdit(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new EditCharacterPage());
            CrossToastPopUp.Current.ShowToastMessage("Pozostałość po edit mode, wywalę soon");
        }

        private void AlignmentChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            App.PlayerController.SelectedCharacter.Alignment = (Alignment)picker.SelectedIndex;
        }
    }
}