using System;
using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Account.Model
{
    public class Page : BaseDBObjectModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public Guid? ParentId { get; set; }

        public string Remark { get; set; }
    }
}
