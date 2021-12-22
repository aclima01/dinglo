using Dinglo.Domain.Entities;

namespace Dinglo.Domain.Authorizations
{
    public interface IUserContext
    {
        AppUser GetUserLoggedin();
    }
}