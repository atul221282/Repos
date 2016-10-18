using Autofac;
using ShareSpecial.Core.ViewModel.Special;
using ShareSpecial.Infrastructure;
using Plugin.Geolocator;
using Xamarin.Forms;
using System.Threading.Tasks;
using ShareSpecial.Core.Helper;
using Newtonsoft.Json;
using ShareSpecial.BusinessEntities.Post;

namespace ShareSpecial
{
    public partial class App : Application
    {
        public static IContainer container;
        public App()
        {
            SetContainer();
            InitializeComponent();
            MainPage = new MainPage(ObjectFactory.Container.Resolve<ISpecialViewModel>());
        }

        private static void SetContainer()
        {

            var data = ObjectFactory.Container;
        }

        async protected override void OnStart()
        {
            // Handle when your app starts
            await GetLocation();
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
