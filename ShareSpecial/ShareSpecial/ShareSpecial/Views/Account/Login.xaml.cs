using ShareSpecial.Core.Service;
using ShareSpecial.Core.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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
            BindingContext = model;
            InitializeComponent();
        }

    }
}
