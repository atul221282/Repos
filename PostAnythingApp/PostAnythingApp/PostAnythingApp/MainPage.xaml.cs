using PostAnythingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PostAnythingApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IMainPageModel MainModel;

        public MainPage(IMainPageModel mainModel)
        {
            MainModel = mainModel;
        }
    }
}
