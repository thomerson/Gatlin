using System.Collections.Generic;

namespace Thomerson.Gatlin.Model.Page
{
    public class PaginationResult<T> : Pagination where T : class
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}
