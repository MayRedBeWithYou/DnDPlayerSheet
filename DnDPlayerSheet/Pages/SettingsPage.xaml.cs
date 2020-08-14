using DnDPlayerSheet.Controllers;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void DownloadDataFromServer(object sender, EventArgs e)
        {
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                CrossToastPopUp.Current.ShowToastMessage("Wymagane połączenie z internetem!");
                return;
            }
            await Navigation.PushModalAsync(new LoadingPage());
            await App.DataProvider.ResetData();
            await App.PlayerController.SelectedCharacter.RestoreSpellsAsync();
            Application.Current.MainPage = new MainPage();
            await Navigation.PopModalAsync();
        }

        private async void ClearCharacters(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoadingPage());
            App.PlayerController.ClearCharacters();
            await App.PlayerController.InitCharacters();
            Application.Current.MainPage = new MainPage();
            await Navigation.PopModalAsync();
        }

        private async void RefreshCharacterSpells(object sender, EventArgs e)
        {
            CrossToastPopUp.Current.ShowToastMessage("Odświeżanie zaklęć w tle, zaraz pojawią się na liście");
            await App.PlayerController.SelectedCharacter.RestoreSpellsAsync();            
        }
    }
}