using Thomerson.Gatlin.Account.Model;

namespace Thomerson.Gatlin.Contract
{
    public interface IUserService : IBaseRepository<User>
    {
        User Get(string userId);
    }
}
