using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model.Criteria;
using Thomerson.Gatlin.Model.Page;

namespace Thomerson.Gatlin.Repository
{
    public class UserRealize : BaseDbRepository<User>, IUserService
    {
        public User Get(string userId)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.SingleOrDefault<User>(new { UserId = userId });
            }
        }

        public Tuple<int, IEnumerable<User>> GetPage(UserCriteria criteria)
        {
            //object predicate
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                var total = conn.Count<User>(null);
                var sort = new List<ISort>();
                foreach (var item in criteria.OyderBy)
                {
                    sort.Add(new Sort()
                    {
                        PropertyName = item.ColumnName,
                        Ascending = item.IsASC
                    });
                }

                return new Tuple<int, IEnumerable<User>>(
                    total,
                    conn.GetPage<User>(null, sort, criteria.CurrentPage, criteria.PageSize
                    ).ToList());
            }
        }
    }
}
