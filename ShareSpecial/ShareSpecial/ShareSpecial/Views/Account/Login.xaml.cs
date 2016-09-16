using ShareSpecial.Core.Helper;
using ShareSpecial.Core.ViewModel.Account;
using ShareSpecial.Helper;
using System;

using Xamarin.Forms;

namespace ShareSpecial.Views.Account
{
    public partial class Login : ContentPage
    {

        private readonly ILoginViewModel Model;
        private readonly ISettingResolver Setting;

        public Login(ILoginViewModel model, ISettingResolver setting)
        {
            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            BindingContext = model;
            this.Setting = setting;
            InitializeComponent();
        }

        protected async void btnGetPost_OnClickedAsync(object sender, EventArgs events)
        {
            var response = await Model.LoginAsync();
            if (response.HasSuccess)
            {
                var answer = await DisplayAlert("wlecome", response.Value.Item2.FullName, "Yes", "No");
            }
        }
    }

}

