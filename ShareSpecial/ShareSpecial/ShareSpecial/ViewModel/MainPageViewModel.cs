using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Service;
using ShareSpecial.Helpers;
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
             IGeolocator locator, INavigationService navigation) : base(navigation)
        {
            this.Service = service;
            this.Navigation = navigation;
            this.locator = locator;
        }

        public async Task<List<PostSpecial>> GetSpecials(double longitude, double latitude, int distance)
        {
            var specials = await HandleResponse(() => this.Service.Special
            .GetSpecialsAsync(longitude, latitude, distance));

            return specials.Value;
        }
    }
}
