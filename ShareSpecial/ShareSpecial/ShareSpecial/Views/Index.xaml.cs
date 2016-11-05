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
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //var data = ObjectFactory.Container;
            App.Current.MainPage = new NavigationPage(new MainPage(ObjectFactory.Container.Resolve<IMainPageViewModel>(),
                ObjectFactory.Container.Resolve<IGeolocator>()));
        }
    }
}
