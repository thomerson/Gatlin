using DapperExtensions;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;

namespace Thomerson.Gatlin.Repository
{
    public class UserRealize : BaseRepository<User>, IUserService
    {
        public User Get(string userId)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.SingleOrDefault<User>(new { UserId = userId });
            }
        }
    }
}
