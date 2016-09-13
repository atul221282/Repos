using ShareSpecial.Core;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IMainViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
