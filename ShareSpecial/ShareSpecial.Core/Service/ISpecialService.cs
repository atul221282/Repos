using ShareSpecial.BusinessEntities.Post;
using ShareSpecial.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public interface ISpecialService
    {
        void AddSpecial();
        Task<Result<List<PostSpecial>>> GetSpecialsAsync(double? longitude, double? latitude, int distance);

        Task<Result<PostSpecial>> GetSpecialAsync(long id);
    }
}
