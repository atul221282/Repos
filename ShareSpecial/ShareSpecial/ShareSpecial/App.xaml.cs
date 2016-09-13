using Autofac;
using ShareSpecial.Core;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            var container = builder.Build();
            //InitializeComponent();
            

            InitializeComponent();

            MainPage = new MainPage(container.Resolve<IMainViewModel>());
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
