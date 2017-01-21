using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.Helpers
{
    public interface INavigationService
    {
        Task PushAsync(Page page);

        Task PushModal(Page page);

        Task PopToRoot();
    }
}
