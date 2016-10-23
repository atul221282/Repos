using Autofac;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShareSpecial.Views
{
    public partial class Index : ContentPage
    {
        public Index()
        {
            var data = ObjectFactory.Container;
            InitializeComponent();
          
        }

        protected override void OnAppearing()
        {
            App.Current.MainPage = new NavigationPage(new MainPage(ObjectFactory.Container.Resolve<IMainPageViewModel>(),
                ObjectFactory.Container.Resolve<IGeolocator>()));
        }
    }
}
