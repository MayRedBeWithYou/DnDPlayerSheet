using DnDLibrary.Models;
using DnDPlayerSheet.XamlExtensions;
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
    public partial class EditCharacterPage : ContentPage
    {
        public static List<string> Alignments { get; } = Enum.GetValues(typeof(Alignment)).OfType<Alignment>()
                                                             .Select(x => EnumToStringConverter.GetDescription(x)).ToList();


        public EditCharacterPage()
        {
            InitializeComponent();
        }

        private void AlignmentChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            App.PlayerController.SelectedCharacter.Alignment = (Alignment)picker.SelectedIndex;
        }
    }
}