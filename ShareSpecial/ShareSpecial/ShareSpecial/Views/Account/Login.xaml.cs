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
            var name = Model.GetEmail();
            using (var client = new HttpClient())
            using (var content =
                new StringContent(
                    JsonConvert.SerializeObject(new { EmailAddress = Model.Email, Password = Model.Password })
                    , Encoding.UTF8, "application/json"))
            {
                var result = await client.PostAsync(@"http://localhost/PostAnything.API/api/Account/Login", content);
                if (result.IsSuccessStatusCode)
                {
                    var answer = await DisplayAlert("wlecome", name, "Yes", "No");
                }
            }


        }

    }
}
