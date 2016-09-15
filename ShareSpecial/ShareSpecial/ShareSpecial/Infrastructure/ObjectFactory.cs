using Autofac;
using Autofac.Core;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using ShareSpecial.Core.ViewModel.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            builder.RegisterType<SpecialService>().As<ISpecialService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<SpecialViewModel>().As<ISpecialViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();

            return builder.Build();
        }

    }

}
