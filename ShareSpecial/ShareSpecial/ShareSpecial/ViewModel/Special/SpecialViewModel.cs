using Plugin.Geolocator.Abstractions;
using ShareSpecial.Core.Service;
using ShareSpecial.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel.Special
{
    public class SpecialViewModel : BaseViewModel, ISpecialViewModel
    {
        private readonly IServiceFactory Service;

        public SpecialViewModel(IServiceFactory service, INavigationService navigation) : base(navigation)
        {
            Service = service;
        }
    }
}
