﻿using Autofac;
using ShareSpecial.BusinessEntity;
using ShareSpecial.Core.Helper;
using ShareSpecial.Helpers;
using ShareSpecial.Infrastructure;
using ShareSpecial.ViewModel.Account;
using ShareSpecial.Views.Account;
using System;
using System.Net;
using System.Threading.Tasks;
using ShareSpecial.Helper;

namespace ShareSpecial.ViewModel
{
    public abstract class BaseViewModel : ObservableObject, IBaseViewModel
    {
        public INavigationService NavigationService { get; set; }
        protected BaseViewModel(INavigationService navigation)
        {
            this.NavigationService = navigation;
        }
        public async Task<T> HandleResponse<T>(Func<Task<T>> action)
        {
            try
            {
                var response = await action.Invoke();
                var result = response as Result;
                if (result != null && result.HasError && result.HttpCode == HttpStatusCode.Unauthorized)
                {
                    var loginVm = ObjectFactory.Container.Resolve<ILoginViewModel>();
                    var helperFac = ObjectFactory.Container.Resolve<IHelperFactory>();
                    var loginView = new Login(loginVm, helperFac);
                    await NavigationService.PushAsync(loginView);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task HandleResponse(Func<Task> func)
        {
            try
            {
                await func.Invoke();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
