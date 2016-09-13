using Autofac;
using ShareSpecial.Core;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Special;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SpecialService>().As<ISpecialService>();
            builder.RegisterType<SpecialViewModel>().As<ISpecialViewModel>();
            var container = builder.Build();

            InitializeComponent();
            MainPage = new MainPage(container.Resolve<ISpecialViewModel>());
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
