
using ShareSpecial.Model;

namespace ShareSpecial.Core.Service
{
    public interface IAccountService
    {
        bool Validate(string email, string password);
        string GetEmail();
    }
}
