

namespace ShareSpecial.Core.Service
{
    public interface IServiceFactory
    {
        ISpecialService Special { get; }

        IAccountService Account { get; }
    }
}
