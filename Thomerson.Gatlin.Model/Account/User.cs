using Thomerson.Gatlin.Model;

namespace Thomerson.Gatlin.Account.Model
{
    public class User : BaseDBObjectModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Remark { get; set; }
    }
}
