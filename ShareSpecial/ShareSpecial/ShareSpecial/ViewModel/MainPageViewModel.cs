using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Service;
using ShareSpecial.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel
{
    public class MainPageViewModel : BaseViewModel, IMainPageViewModel
    {
        private readonly IServiceFactory Service;
        private ObservableCollection<PostSpecial> _specials;

        public IGeolocator locator;
        public Command GetSpecialCommand { get; }

        public MainPageViewModel(IServiceFactory service,
             IGeolocator locator, INavigationService navigation) : base(navigation)
        {
            this.Service = service;
            this.Navigation = navigation;
            this.locator = locator;

            GetSpecialCommand = new Command(async (x) => await ExecuteGetSpecialsCommand(x as Position));
        }

        /// <summary>
        /// This property is bind to listview on mainpage.xaml
        /// </summary>
        public ObservableCollection<PostSpecial> PostSpecials
        {
            get { return _specials; }
            set
            {
                SetProperty(ref _specials, value);
            }
        }


        private async Task ExecuteGetSpecialsCommand(Position position)
        {
            position = position ?? (await GetLocation())?.Value;
            PostSpecials = new ObservableCollection<PostSpecial>(await GetSpecials(position.Longitude, position.Latitude, 5000));
        }

        #region "Private methods"

        private async Task<List<PostSpecial>> GetSpecials(double longitude, double latitude, int distance)
        {
            var specials = await HandleResponse(() => this.Service.Special
            .GetSpecialsAsync(longitude, latitude, distance));

            return specials.Value;
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

        #endregion
    }
}
