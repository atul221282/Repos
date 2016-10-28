using Autofac;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Service;
using ShareSpecial.Helpers;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Special;
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
        private PostSpecial _postSpecial;

        public IGeolocator locator;
        public Command LoadSpecialListCommand { get; }
        public Command LoadSpecialCommand { get; }

        public MainPageViewModel(IServiceFactory service,
             IGeolocator locator, INavigationService navigation) : base(navigation)
        {
            this.Service = service;
            this.Navigation = navigation;
            this.locator = locator;

            LoadSpecialListCommand = new Command(async (x) => await ExecuteLoadSpecialListCommand(null));

            LoadSpecialCommand = new Command(async (x) => await ExecuteLoadSpecial(x as PostSpecial));
        }

        private async Task ExecuteLoadSpecial(PostSpecial special)
        {
            var vm = ObjectFactory.Container.Resolve<ISpecialDetailViewModel>();
            vm.Special = special;
            await Navigation.PushAsync(new Detail(vm));
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
        
        private async Task ExecuteLoadSpecialListCommand(Position position)
        {
            try
            {
                position = position ?? (await GetLocation())?.Value;
                var specials = await GetSpecials(position.Longitude, position.Latitude, 5000);
                PostSpecials = new ObservableCollection<PostSpecial>(specials);
            }
            catch (Exception ex)
            {
                var gg = ex;
            }
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
