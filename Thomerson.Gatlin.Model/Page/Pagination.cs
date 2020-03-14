namespace Thomerson.Gatlin.Model.Page
{
    public class Pagination
    {
        private int _CurrentPage;
        public int CurrentPage
        {
            get { return _CurrentPage > 0 ? _CurrentPage : 1; }
            set { _CurrentPage = value; }
        }
        private int _PageSize { get; set; }
        public int PageSize
        {
            get { return _PageSize > 0 ? _CurrentPage : 20; }
            set { _CurrentPage = value; }
        }

        public string OyderBy { get; set; }
        public string OyderByDesc { get; set; }

    }
}
