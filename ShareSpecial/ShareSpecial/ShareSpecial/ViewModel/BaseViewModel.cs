using ShareSpecial.BusinessEntity;
using ShareSpecial.Views.Special;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel
{
    public abstract class BaseViewModel
    {
        protected  Application application;
        protected async Task<T> HandleResponse<T>(Func<Task<T>> action)
        {
            try
            {
                var response = await action.Invoke();
                var result = response as Result;
                if (result != null && result.HasError && result.HttpCode == HttpStatusCode.Unauthorized)
                {
                    await application.MainPage.Navigation.PushAsync(new Index());
                }
                return response;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        protected async Task HandleResponse(Func<Task> func)
        {
            try
            {
                await func.Invoke();
            }
            catch (Exception ex)
            {
                var ff = ex;
                throw;
            }
        }
    }
}
