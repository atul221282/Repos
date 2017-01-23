using ShareSpecial.Views.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.Views.Layout
{
    public class HomeTabbed : TabbedPage
    {
        public HomeTabbed()
        {
            var navigationPage = new NavigationPage(new Special.Index());
            //navigationPage.Icon = "schedule.png";
            navigationPage.Title = "Special";

            Children.Add(new Page1());
            Children.Add(navigationPage);
            Children.Add(new Page2());
            Children.Add(new Page1());
            Children.Add(new Page2());
        }
    }
}
