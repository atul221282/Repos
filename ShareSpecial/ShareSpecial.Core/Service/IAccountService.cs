
using ShareSpecial.Model;
using System.Threading.Tasks;

namespace ShareSpecial.Core.Service
{
    public interface IAccountService
    {
        string GetEmail();
        Task<bool> LoginAsync(string email, string password);
    }
}
