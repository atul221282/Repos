using Newtonsoft.Json;
using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShareSpecial.Views.Account
{
    public partial class Login : ContentPage
    {

        private readonly ILoginViewModel Model;

        public Login(ILoginViewModel model)
        {
            this.Model = model;
            Model.Email = "bsharma2422@gmail.com";
            BindingContext = model;
            InitializeComponent();
        }

        protected async void btnGetPost_OnClickedAsync(object sender, EventArgs events)
        {
            if (await Model.LoginAsync())
            {
                var answer = await DisplayAlert("wlecome", Model.Email, "Yes", "No");
            }
        }
    }

}

