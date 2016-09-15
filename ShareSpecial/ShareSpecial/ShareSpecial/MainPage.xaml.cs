using Autofac;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using ShareSpecial.Core.ViewModel.Special;
using ShareSpecial.Infrastructure;
using ShareSpecial.Model.Constant;
using ShareSpecial.Views.Account;
using System;
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
            var page = new Login(ObjectFactory.Container.Resolve<ILoginViewModel>());
            App.Current.MainPage = new NavigationPage(page);
        }
    }

}
