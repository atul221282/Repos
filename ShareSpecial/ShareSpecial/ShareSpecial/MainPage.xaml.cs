using Autofac;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Account;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {
        private readonly IMainPageViewModel ViewModel;
        private readonly IGeolocator locator;
        public MainPage(IMainPageViewModel vm, IGeolocator locator)
        {
            this.ViewModel = vm;
            this.locator = locator;
            BindingContext = ViewModel;
            InitializeComponent();
        }
        async protected override void OnAppearing()
        {
            var positionResult = await GetLocation();
            if (positionResult.HasSuccess)
            {
                await Navigation.PushAsync(new Login(null, null, null));
                SpecialList.ItemsSource = await
                    ViewModel.GetSpecials(positionResult.Value.Longitude, positionResult.Value.Latitude, 5000);
            }
        }

        private async Task<Result<Position>> GetLocation()
        {
            locator.DesiredAccuracy = 100; //100 is new default
            if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
            {
                try
                {
                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 6000);
                    return Result.Ok(position);
                }
                catch (Exception ex)
                {
                    //log ex;
                    return Result.Error<Position>(ex);
                }
            }
            return Result.Error<Position>("Cannot access location");
        }
    }

}
