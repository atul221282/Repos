using Autofac;
using ShareSpecial.Infrastructure;
using Plugin.Geolocator;
using Xamarin.Forms;
using System.Threading.Tasks;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.ViewModel;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.Views;
using ShareSpecial.Views.Layout;

namespace ShareSpecial
{
    public partial class App : Application
    {
        public static IContainer container;
        public App()
        {
            InitializeComponent();

            SetContainer();

            //MainPage = new NavigationPage(new MainPage(ObjectFactory.Container.Resolve<IMainPageViewModel>(),
            //    ObjectFactory.Container.Resolve<IGeolocator>()));
            //MainPage = new Home();
            MainPage = new MasterDetailLearningPage();
            //MainPage = new HomeTabbed();
        }

        private static void SetContainer()
        {
            var data = ObjectFactory.Container;
        }

        protected override void OnStart()
        {

        }

        private async Task GetLocation()
        {
            var locator = CrossGeolocator.Current;
            if (locator.IsGeolocationEnabled)
            {
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                //ObjectFactory.Container.Resolve<IHelperFactory>().Setting.Location = new PostLocation { Latitude = position.Latitude, Longitude = position.Longitude };
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
