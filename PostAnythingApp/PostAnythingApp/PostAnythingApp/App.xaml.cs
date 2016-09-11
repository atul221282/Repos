using Autofac;
using PostAnythingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PostAnythingApp
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<MainPageModel>().As<IMainPageModel>();
            var container = builder.Build();
            //InitializeComponent();
            MainPage = new MainPage(container.Resolve<IMainPageModel>());
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
