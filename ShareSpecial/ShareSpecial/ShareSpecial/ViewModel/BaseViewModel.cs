using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.ViewModel
{
    public abstract class BaseViewModel
    {
        protected async Task<T> HandleResponse<T>(Func<Task<T>> action)
        {
            try
            {
                return await action.Invoke();
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
