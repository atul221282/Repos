using Newtonsoft.Json;
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
        private readonly IGeolocator locator;
        public Login(ILoginViewModel model, IHelperFactory helper, IGeolocator locator)
        {

            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            Model.Password = "123456";
            BindingContext = model;
            this.Helper = helper;
            this.locator = locator;

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
            if (response != null && response.HasSuccess)
            {
                var result = await Model.GetSpecialAsync(1);
            }
        }

        async protected override void OnAppearing()
        {
            //await SetLocation();
        }
    }
}

