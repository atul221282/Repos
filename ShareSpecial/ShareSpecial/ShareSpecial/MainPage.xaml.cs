﻿using Autofac;
using ShareSpecial.Core.Helper;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Account;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {

        private readonly ISpecialViewModel ViewModel;

        public MainPage(ISpecialViewModel vm)
        {
            this.ViewModel = vm;
            BindingContext = ViewModel;
            InitializeComponent();
        }
        async protected override void OnAppearing()
        {
            //todo load application data here
            //todo then navigate from here
            var page = new Login(ObjectFactory.Container.Resolve<ILoginViewModel>(),
                ObjectFactory.Container.Resolve<IHelperFactory>());
            App.Current.MainPage = new NavigationPage(page);
        }
    }

}
