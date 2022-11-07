namespace Treaning.WebAPI.Utils
{
    public class PaginationParams
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int SkipCount { get {
                                        return (PageIndex - 1) * PageSize;
                                    } 
        }
    }
}
    