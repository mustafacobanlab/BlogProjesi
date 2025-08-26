namespace KisiselBlogProjesi.RequestParameters
{
    public class BlogRequestParameters
    {
        public BlogRequestParameters() : this(1, 6)
        {
        }
        public BlogRequestParameters(int pageNumber = 1, int pageSize = 6)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }


    }
}
