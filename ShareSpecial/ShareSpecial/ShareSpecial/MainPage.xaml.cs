using ShareSpecial.Core;
using ShareSpecial.Core.ViewModel.Special;
using Xamarin.Forms;

namespace ShareSpecial
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ISpecialViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
