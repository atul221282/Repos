using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel
{
    public class MainPageViewModel : BaseViewModel, IMainPageViewModel
    {
        private readonly IServiceFactory Service;
        public IEnumerable<PostSpecial> PostSpecials { get; set; }
        public IGeolocator locator;

        public MainPageViewModel(IServiceFactory service,
            Application application, IGeolocator locator):base(application)
        {
            this.Service = service;
            this.application = application;
            this.locator = locator;
        }

        public async Task LoadSpecials()
        {
            var location = await GetLocation();
            var specials = await HandleResponse(() => this.Service.Special
            .GetSpecialsAsync(location.Value.Longitude, location.Value.Latitude, 5000));
            if (specials.HasSuccess)
                this.PostSpecials = specials.Value;
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
