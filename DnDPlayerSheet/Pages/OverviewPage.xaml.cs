using DnDLibrary.Models;
using DnDPlayerSheet.Controllers;
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
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return "null";

            return GetDescription((Enum)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
            }
            return en.ToString();
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        public bool IsInEditMode { get; set; } = false;

        public static List<string> Roles = new List<string>();

        public OverviewPage()
        {
            List<Role> roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
            foreach(Role r in roles)
            {
                Roles.Add(EnumConverter.GetDescription(r));
            }
            InitializeComponent();
            BindingContext = this;
        }

        private async void CharacterNameChanged(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Nazwa postaci", "", initialValue: App.PlayerController.SelectedCharacter.Name, maxLength: 30, keyboard: Keyboard.Text);
            if (name != null)
            {
                App.PlayerController.SelectedCharacter.RemoveFile();
                App.PlayerController.SelectedCharacter.Name = name;
                App.PlayerController.SelectedCharacter.SaveToFile();
            }
        }

        private void ToggleEditMode(bool check)
        {
            CharacterName.IsReadOnly = !check;
        }

        private void CharacterChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            App.PlayerController.SelectedCharacter = App.PlayerController.Characters[picker.SelectedIndex];
        }

        private void MaterialButton_Clicked(object sender, EventArgs e)
        {
            IsInEditMode = !IsInEditMode;
            if (IsInEditMode)
            {
                EditModeButton.Text = IconFont.Floppy;
                ToggleEditMode(true);
            }
            else
            {
                EditModeButton.Text = IconFont.Pencil;
                ToggleEditMode(false);
                App.PlayerController.SelectedCharacter.SaveToFile();
            }
        }
    }
}