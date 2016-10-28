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
using ShareSpecial.Helpers;

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

            builder.RegisterInstance(current).As<Application>().SingleInstance();
            builder.RegisterInstance(CrossGeolocator.Current).As<IGeolocator>().ExternallyOwned().SingleInstance();

            builder.RegisterType<HelperFactory>().As<IHelperFactory>().SingleInstance();
            builder.RegisterType<ServiceFactory>().As<IServiceFactory>().SingleInstance();

            builder.RegisterType<Result>().As<IResult>().SingleInstance();

            builder.RegisterType<HttpClientService>().As<IHttpClientService>().SingleInstance();
            builder.RegisterType<HttpClientResolver>().As<IHttpClientResolver>().SingleInstance();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<SpecialService>().As<ISpecialService>().SingleInstance();
            builder.RegisterType<AccountService>().As<IAccountService>().SingleInstance();
            builder.RegisterType<SettingResolver>().As<ISettingResolver>().SingleInstance();

            builder.RegisterType<NavigationService>().As<INavigationService>();

            builder.RegisterType<MainPageViewModel>().As<IMainPageViewModel>();
            builder.RegisterType<SpecialViewModel>().As<ISpecialViewModel>();
            builder.RegisterType<SpecialDetailViewModel>().As<ISpecialDetailViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
           
            return builder.Build();
        }
    }
}
