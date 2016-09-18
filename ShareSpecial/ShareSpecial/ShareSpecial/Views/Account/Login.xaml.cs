using ShareSpecial.Core.Helper;
using ShareSpecial.Core.ViewModel.Account;
using System;

using Xamarin.Forms;

namespace ShareSpecial.Views.Account
{
    public partial class Login : ContentPage
    {

        private readonly ILoginViewModel Model;
        private readonly IHelperFactory Helper;

        public Login(ILoginViewModel model, IHelperFactory helper)
        {
            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            BindingContext = model;
            this.Helper = helper;
            var pp = helper.Setting.Location;
            Model.Latitude = pp.Latitude;
            Model.Longitude = pp.Longitude;
            InitializeComponent();
            //lat - 34.810579350003934
            //long 138.68080767575302
        }

        protected async void btnLogin_OnClickedAsync(object sender, EventArgs events)
        {
            var response = await Model.LoginAsync();
            
            if (response.HasError)
            {
                await DisplayAlert("Error", response.Errors, "Ok");
            }
            else
            {
                Helper.Setting.User = response.Value.Item2;
                Helper.Setting.Token = response.Value.Item1;

                var answer = await DisplayAlert("wlecome", Helper.Setting.User.FullName, "Yes", "No");
            }
        }

        protected async void btnGetPost_OnClickedAsync(object sender, EventArgs events)
        {
            var response = await Model.GetSpecials();
            if(response.HasSuccess)
            {
                
            }
        }

        protected override void OnAppearing()
        {

        }
    }

}

