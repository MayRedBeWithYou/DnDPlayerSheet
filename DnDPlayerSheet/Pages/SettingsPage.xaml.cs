using DnDPlayerSheet.Controllers;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void DownloadDataFromServer(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoadingPage());
            await App.DataProvider.ResetData();
            await App.PlayerController.SelectedCharacter.RestoreSpellsAsync();
            Application.Current.MainPage = new Main();
            await Navigation.PopModalAsync();
        }

        private async void MaterialButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoadingPage());
            App.PlayerController.ClearCharacters();
            await App.PlayerController.InitCharacters();
            Application.Current.MainPage = new Main();
            await Navigation.PopModalAsync();
        }
    }
}