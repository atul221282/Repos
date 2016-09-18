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

        private readonly IAccountService Service;

        public LoginViewModel(IAccountService service)
        {
            this.Service = service;
            this.Email = service.GetEmail();
        }
        public string Email { get; set; }

        public string Password { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public int Distance { get; set; } = 9000;

        public string GetEmail() => $"{Email} welcome to xamarin";

        public async Task<Result<List<PostSpecial>>> GetSpecials() => await Service.GetSpecialsAsync(Longitude, Latitude, Distance);

        public async Task<Result<Tuple<Token, Users>>> LoginAsync() => await Service.LoginAsync(Email, Password);

        public async Task<Result<PostSpecial>> GetSpecialAsync(long id) => await Service.GetSpecialAsync(id);
    }
}
