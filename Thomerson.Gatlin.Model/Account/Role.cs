using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Account.Model
{
    public class Role : BaseDBObjectModel
    {
        public string Name { get; set; }

        public string Remark { get; set; }
    }
}
