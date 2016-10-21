using Autofac;
using Plugin.Geolocator.Abstractions;
using ShareSpecial.Core.Helper;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Account;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {

        private readonly IMainPageViewModel ViewModel;

        public MainPage(IMainPageViewModel vm)
        {
            this.ViewModel = vm;
            BindingContext = ViewModel;
            InitializeComponent();
        }
        async protected override void OnAppearing()
        {
            await ViewModel.LoadSpecials();
            SpecialList.ItemsSource = ViewModel.PostSpecials;
        }
    }

}
