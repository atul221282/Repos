using Newtonsoft.Json;
using Plugin.Geolocator;
using ShareSpecial.Core.Helper;
using ShareSpecial.Core.ViewModel.Account;
using System;
using System.Threading;
using System.Threading.Tasks;
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
            Model.Password = "123456";
            BindingContext = model;
            this.Helper = helper;
            InitializeComponent();
            //lat - 34.810579350003934
            //long 138.68080767575302
        }

        protected async void btnLogin_OnClickedAsync(object sender, EventArgs events)
        {
            //await SetLocation();

            var response = await Model.LoginAsync();

            if (response.HasError)
            {
                await DisplayAlert("Error", response.Errors, "Ok");
            }
            else
            {
                Helper.Setting.User = response.Value.Item2;
                var token = response.Value.Item1;
                Settings.TokenExpiry = DateTime.Now.AddSeconds(token.expires_in).ToString();
                Settings.Token = JsonConvert.SerializeObject(token);
                var answer = await DisplayAlert("wlecome", Helper.Setting.User.FullName, "Yes", "No");
            }
        }

        protected async void btnGetPost_OnClickedAsync(object sender, EventArgs events)
        {
            var response = await Model.GetSpecialsAsync();
            if (response.HasSuccess)
            {
                var special = await Model.GetSpecialAsync(1);
            }
        }

        async protected override void OnAppearing()
        {
            await SetLocation();
        }

        private async Task SetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100; //100 is new default
            if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
            {
                try
                {
                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
                    Model.Latitude = position.Latitude;
                    Model.Longitude = position.Longitude;
                }
                catch (Exception ex)
                {
                    //log ex;
                    var ff = ex;
                }
            }
        }
    }
}

