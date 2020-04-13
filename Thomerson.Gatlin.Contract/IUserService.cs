using System;
using System.Collections.Generic;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Model.Criteria;
using Thomerson.Gatlin.Model.Page;

namespace Thomerson.Gatlin.Contract
{
    public interface IUserService : IBaseRepository<User>
    {
        User Get(string userId);

        Tuple<int, IEnumerable<User>> GetPage(UserCriteria criteria);
    }
}
