using Autofac;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using ShareSpecial.Core.ViewModel.Special;
using System;

using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;

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

            //builder.Register(x => new HttpClient());
            builder.RegisterType<Result>().As<IResult>();
            builder.RegisterType<HttpClientResolver>().As<IHttpClientResolver>();
            builder.RegisterType<SpecialService>().As<ISpecialService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<SettingResolver>().As<ISettingResolver>();
            builder.RegisterType<SpecialViewModel>().As<ISpecialViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();

            return builder.Build();
        }

    }

}
