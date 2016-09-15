using Autofac;
using ShareSpecial.Core;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using ShareSpecial.Core.ViewModel.Special;
using ShareSpecial.Infrastructure;
using ShareSpecial.Model.Constant;
using Xamarin.Forms;

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

        protected override void OnStart()
        {
            // Handle when your app starts
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
