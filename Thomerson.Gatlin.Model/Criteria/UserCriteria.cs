using Thomerson.Gatlin.Model.Page;

namespace Thomerson.Gatlin.Model.Criteria
{
    public class UserCriteria : Pagination
    {
        public string Name { get; set; }
        public string RoleId { get; set; }
    }
}
