﻿using DnDPlayerSheet.Controllers;
using DnDPlayerSheet.Helpers;
using DnDPlayerSheet.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDPlayerSheet
{
    public partial class App : Application
    {
        public static IDataProvider DataProvider { get; } = new LocalDataProvider();

        public static PlayerController PlayerController { get; } = new PlayerController();

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Secrets.SyncfusionKey);

            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            MainPage = new LoadingPage();
        }

        protected override async void OnStart()
        {
            await DataProvider.InitializeAsync();
            await PlayerController.InitCharacters();

            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
