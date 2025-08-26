namespace KisiselBlogProjesi.Models
{
    public class BlogListViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Pagination Pagination { get; set; }
    }
}
