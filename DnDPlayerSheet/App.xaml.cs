using DnDPlayerSheet.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet
{
    public partial class App : Application
    {
        public static PlayerController PlayerController { get; } = new PlayerController();

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);

            MainPage = new Main();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
