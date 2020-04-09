using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Thomerson.Gatlin.Account.Model;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Model.Page;

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

        public Tuple<int, IEnumerable<User>> GetPage(object predicate, Pagination pagination)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                var total = conn.Count<User>(predicate);
                var sort = new List<ISort>();
                foreach (var item in pagination.OyderBy)
                {
                    sort.Add(new Sort()
                    {
                        PropertyName = item.ColumnName,
                        Ascending = item.IsASC
                    });
                }

                return new Tuple<int, IEnumerable<User>>(
                    total,
                    conn.GetPage<User>(predicate, sort, pagination.CurrentPage, pagination.PageSize
                    ).ToList());
            }
        }
    }
}
