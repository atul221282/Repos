using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.Helpers
{
    public class NavigationService : INavigationService
    {
        private readonly Application application;

        public NavigationService(Application application)
        {
            this.application = application;
        }
        public async Task PushAsync(Page page)
        {
            await application.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModal(Page page)
        {
            await application.MainPage.Navigation.PushModalAsync(page);
        }

        public async Task PopToRoot()
        {
            await application.MainPage.Navigation.PopToRootAsync();
        }
    }
}
