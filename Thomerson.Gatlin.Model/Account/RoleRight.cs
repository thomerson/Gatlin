using System;
using System.Collections.Generic;
using System.Text;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Account.Model
{
    public class RoleRight : BaseModel
    {
        public Guid RoleId { get; set; }
        public Guid RightId { get; set; }
    }
}
