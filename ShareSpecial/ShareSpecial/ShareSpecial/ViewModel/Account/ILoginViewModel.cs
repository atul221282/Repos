using ShareSpecial.BusinessEntities;
using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using ShareSpecial.BusinessEntity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.ViewModel.Account
{
    public interface ILoginViewModel : IBaseViewModel
    {
        string Email { get; set; }

        string Password { get; set; }

        double? Longitude { get; set; }

        double? Latitude { get; set; }

        int Distance { get; set; }

        string GetEmail();

        Task<Result<Tuple<Token, Users>>> LoginAsync();

        Task<Result<List<PostSpecial>>> GetSpecialsAsync();

        Task<Result<PostSpecial>> GetSpecialAsync(long id);

        Task GotoHome();
    }
}
