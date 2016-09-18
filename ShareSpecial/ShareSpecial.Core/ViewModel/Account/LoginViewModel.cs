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

namespace ShareSpecial.Core.ViewModel.Account
{
    public class LoginViewModel : ILoginViewModel
    {

        private readonly IServiceFactory Service;

        public LoginViewModel(IServiceFactory service)
        {
            this.Service = service;
            this.Email = service.Account.GetEmail();
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public int Distance { get; set; } = 9000;

        public string GetEmail() => $"{Email} welcome to xamarin";

        public async Task<Result<List<PostSpecial>>> GetSpecialsAsync() => await Service.Special.GetSpecialsAsync(Longitude, Latitude, Distance);

        public async Task<Result<Tuple<Token, Users>>> LoginAsync() => await Service.Account.LoginAsync(Email, Password);

        public async Task<Result<PostSpecial>> GetSpecialAsync(long id) => await Service.Special.GetSpecialAsync(id);
    }
}
