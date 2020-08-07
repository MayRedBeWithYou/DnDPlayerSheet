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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void MaterialButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CurrentPWChanged(object sender, EventArgs e)
        {
            var stepper = sender as Stepper;
            CurrentPWLabel.Text = stepper.Value.ToString() + " /";
        }
    }
}