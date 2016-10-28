using Autofac;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Account;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {
        private readonly IMainPageViewModel ViewModel;
        private readonly IGeolocator locator;


        public MainPage(IMainPageViewModel vm, IGeolocator locator)
        {
            this.ViewModel = vm;
            this.locator = locator;
            BindingContext = ViewModel;
            InitializeComponent();

        }

        async protected override void OnAppearing()
        {
                ViewModel.GetSpecialCommand.Execute(null);
        }
    }
}
