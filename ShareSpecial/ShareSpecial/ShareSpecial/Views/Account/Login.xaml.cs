﻿using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.Core.Helper;
using ShareSpecial.ViewModel.Account;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.Views.Account
{
    public partial class Login : ContentPage
    {

        private readonly ILoginViewModel Model;
        private readonly IHelperFactory Helper;
        private bool _canClose = true;

        public Login(ILoginViewModel model, IHelperFactory helper)
        {
            InitializeComponent();

            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            Model.Password = "123456";
            BindingContext = model;
            this.Helper = helper;
            //lat - 34.810579350003934
            //long 138.68080767575302
        }

        protected async void Login_OnClickedAsync(object sender, EventArgs events)
        {
            Model.IsBusy = true;
            //await SetLocation();
            var response = await Model.LoginAsync();
            Model.IsBusy = false;
            if (response.HasError)
                await DisplayAlert("Error", response.Errors, "Ok");
            else
            {
                var answer = await DisplayAlert("wlecome", Helper.Setting.User.FullName, "Yes", "No");
            }
        }

        async protected override void OnAppearing()
        {
        }
        
        protected override bool OnBackButtonPressed()
        {
            return CanNavigate();
        }

        private bool CanNavigate()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("", "Do you wan't to exit the App?", "Yes", "No");
            if (answer)
            {
                _canClose = answer;
                await Model.GotoHome();
            }
        }

    }
}

