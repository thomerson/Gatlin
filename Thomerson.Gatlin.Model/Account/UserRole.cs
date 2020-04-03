using System;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Account.Model
{
    public class UserRole : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

    }
}
