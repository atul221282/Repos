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
        public Login(ILoginViewModel model, IHelperFactory helper)
        {
            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            Model.Password = "123456";
            BindingContext = model;
            this.Helper = helper;
            locator = CrossGeolocator.Current;

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

            var response = await HandleResponse(() => Model.GetSpecialsAsync());
            if (response != null && response.HasSuccess)
            {
                var result = await HandleResponse(() => Model.GetSpecialAsync(1));
            }
        }

        async protected override void OnAppearing()
        {
            await HandleResponse(() => SetLocation());
        }

        private async Task SetLocation()
        {
            locator.DesiredAccuracy = 100; //100 is new default
            if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
            {
                try
                {
                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 6000);
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

        private async Task<T> HandleResponse<T>(Func<Task<T>> action)
        {
            try
            {
                return await action.Invoke();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        private async Task HandleResponse(Func<Task> func)
        {
            try
            {
                await func.Invoke();
            }
            catch (Exception ex)
            {
                var ff = ex;
                throw;
            }
        }
    }
}

