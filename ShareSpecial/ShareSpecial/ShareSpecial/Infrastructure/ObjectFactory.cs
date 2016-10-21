using Autofac;
using ShareSpecial.Core.Service;
using System;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using Xamarin.Forms;
using System.Reflection;
using ShareSpecial.ViewModel;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace ShareSpecial.Infrastructure
{
    public class ObjectFactory
    {
        private static readonly Lazy<IContainer> lazy =
        new Lazy<IContainer>(() => Components());

        public static IContainer Container => lazy.Value;
        private ObjectFactory()
        {
        }

        public static IContainer Components()
        {
            var builder = new ContainerBuilder();
            var current = Application.Current;

            builder.RegisterInstance(current).As<Application>().ExternallyOwned();
            builder.RegisterInstance(CrossGeolocator.Current).As<IGeolocator>().ExternallyOwned();
            //builder.Register(x => new HttpClient());
            builder.RegisterType<HelperFactory>().As<IHelperFactory>();
            builder.RegisterType<ServiceFactory>().As<IServiceFactory>();

            builder.RegisterType<Result>().As<IResult>();

            builder.RegisterType<HttpClientService>().As<IHttpClientService>();
            builder.RegisterType<HttpClientResolver>().As<IHttpClientResolver>();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>();


            builder.RegisterType<SpecialService>().As<ISpecialService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<SettingResolver>().As<ISettingResolver>();

            builder.RegisterType<MainPageViewModel>().As<IMainPageViewModel>();
            builder.RegisterType<SpecialViewModel>().As<ISpecialViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();

            return builder.Build();
        }

    }

}
