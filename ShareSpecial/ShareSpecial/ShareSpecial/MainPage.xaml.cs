using ShareSpecial.Core;
using ShareSpecial.Core.ViewModel.Special;
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

        protected async void btnGetPost_OnClickedAsync(object sender, EventArgs events)
        {
            var name = ViewModel.GetName();
            var answer = await DisplayAlert("Question?", "Would you like to play a game " + name, "Yes", "No");
        }
    }

}
