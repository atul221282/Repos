using ShareSpecial.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel
{
    public interface IBaseViewModel
    {
        INavigationService NavigationService { get; set; }

        Task<T> HandleResponse<T>(Func<Task<T>> action);

        Task HandleResponse(Func<Task> func);
    }
}