using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Identity;
using ShareSpecial.Core.Helper;
using ShareSpecial.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpecial.BusinessEntities.Post;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel.Account
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {

        private readonly IServiceFactory Service;
        private readonly IHelperFactory Helper;

        public LoginViewModel(IServiceFactory service, Application application)
        {
            this.Service = service;
            this.application = application;
            this.Email = service.Account.GetEmail();
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public int Distance { get; set; } = 9000;

        public string GetEmail() => $"{Email} welcome to xamarin";

        public async Task<Result<List<PostSpecial>>> GetSpecialsAsync()
            => await HandleResponse(() => Service.Special.GetSpecialsAsync(Longitude, Latitude, Distance));

        public async Task<Result<Tuple<Token, Users>>> LoginAsync()
            => await HandleResponse(() => Service.Account.LoginAsync(Email, Password));

        public async Task<Result<PostSpecial>> GetSpecialAsync(long id)
            => await HandleResponse(() => Service.Special.GetSpecialAsync(id));
    }
}
