using Autofac;
using ShareSpecial.Core.Helper;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.ViewModel.Special;
using ShareSpecial.Views.Account;
using ShareSpecial.Views.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.Views.Layout
{
    public partial class Home : MasterDetailPage
    {

        public Home()
        {
            //NavigationPage.set
            var listView = new ListView();
            listView.ItemsSource = GetList();

            Master = new ContentPage
            {
                Title = "Coarses",
                Content = listView,
                Padding = new Thickness(0, 40, 0, 0),
                Icon = "hamburger.png"
            };

            listView.ItemSelected += ListView_ItemSelected;

            var personDataTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Title");
                return new ViewCell { View = nameLabel };
            });

            listView.ItemTemplate = personDataTemplate;

            Detail = new NavigationPage(new Login(ObjectFactory.Container.Resolve<ILoginViewModel>(),
                ObjectFactory.Container.Resolve<IHelperFactory>()));
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var name = (e.SelectedItem as MasterPageItem).TargetType.Name;
            switch (name)
            {
                case "Detail":
                    Detail = new NavigationPage(new Detail(ObjectFactory.Container.Resolve<ISpecialDetailViewModel>()));
                    Detail.Title = "Special Detail";
                    
                    break;
                case "Index":
                    Detail = new NavigationPage(new Special.Index());
                    Detail.Title = "Specials";
                    break;
                default:
                    Detail = new NavigationPage(new Login(ObjectFactory.Container.Resolve<ILoginViewModel>(),
                        ObjectFactory.Container.Resolve<IHelperFactory>()));
                    Detail.Title = "Login";
                    break;
            }
            IsPresented = Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop;
        }

        private IEnumerable<MasterPageItem> GetList()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Contacts",
                IconSource = "contacts.png",
                TargetType = typeof(Login)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "TodoList",
                IconSource = "todo.png",
                TargetType = typeof(Index)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Reminders",
                IconSource = "reminders.png",
                TargetType = typeof(Special.Detail)
            });

            return masterPageItems;
        }
    }
}
