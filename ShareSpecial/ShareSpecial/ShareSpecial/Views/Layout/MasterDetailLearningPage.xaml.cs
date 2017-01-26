using ShareSpecial.Views.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShareSpecial.Views.Layout
{
    public partial class MasterDetailLearningPage : MasterDetailPage
    {
        public MasterDetailLearningPage()
        {
            InitializeComponent();
            listView.ItemsSource = MasterPageItem.GetList();
            Detail = new NavigationPage(new Page1());
            IsPresented = false;
        }

        protected void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var name = (e.Item as MasterPageItem)?.TargetType.Name;
            switch (name)
            {
                case "Page1":
                    Detail = new NavigationPage(new Page1());
                    break;
                case "Page2":
                    Detail = new NavigationPage(new Page2());
                    break;
                default:
                    throw new NotImplementedException();
            }
            IsPresented = Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop;
        }
    }
}
