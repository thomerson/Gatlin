using Thomerson.Gatlin.Model;
using System.ComponentModel.DataAnnotations;

namespace Thomerson.Gatlin.Account.Model
{
    public class User : BaseDBObjectModel
    {
        [MaxLength(128)]
        public string UserId { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string EnglishName { get; set; }

        [MaxLength(32)]
        public string Phone { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(256)]
        public string Salt { get; set; }

        public string Remark { get; set; }
    }
}
