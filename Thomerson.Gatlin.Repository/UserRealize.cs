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

        public PaginationResult<User> GetPage(UserCriteria criteria)
        {
            //object predicate
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                var total = conn.Count<User>(null);
                var sort = new List<ISort>();
                if (criteria.OyderBy != null && criteria.OyderBy.Count > 0)
                {
                    foreach (var item in criteria.OyderBy)
                    {
                        sort.Add(new Sort()
                        {
                            PropertyName = item.ColumnName,
                            Ascending = item.IsASC
                        });
                    }
                }
                else
                {
                    sort.Add(new Sort()
                    {
                        PropertyName = nameof(User.CreateStamp),
                        Ascending = false
                    });
                }

                var list = conn.GetPage<User>(null, sort, criteria.CurrentPage, criteria.PageSize).ToList();

                return new PaginationResult<User>()
                {
                    Total = total,
                    Data = list,
                    PageSize = criteria.PageSize,
                    CurrentPage = criteria.CurrentPage,
                    OyderBy = criteria.OyderBy
                };
            }
        }
    }
}
