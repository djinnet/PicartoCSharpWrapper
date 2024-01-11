
namespace PicartoWrapperAPI.Helpers
{
    public class PagingInfo
    {
        private int _pageSize;
        private const int MaxPageSize = 100;

        public PagingInfo()
        {
            Page = 1;
            PageSize = 25;
            ViewAll = false;
        }

        protected PagingInfo(PagingInfo pagingInfo)
        {
            Page = pagingInfo.Page;
            PageSize = pagingInfo.PageSize;
            ViewAll = pagingInfo.ViewAll;
        }

        public int Page { get; set; }

        public bool ViewAll { get; set; }

        public int PageSize
        {
            get { return ViewAll ? MaxPageSize : _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }


        public int Skip
        {
            get { return (Page - 1) * PageSize; }
        }
    }
}
