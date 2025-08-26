using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.RequestParameters;

namespace KisiselBlogProjesi.Repositories.Contracts
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        IQueryable<Blog> GettAllBlog(bool trackChanges);

        IQueryable<Blog> GettAllBlogsWithDetails(BlogRequestParameters p);

        Blog? GetOneBlogs(int id, bool trackChanges);
        Blog? GetOneBlog(int id, bool trackChanges);
        void CreateOneBlog(Blog blog);
        void DeleteOneBlog(Blog blog);
        void UpdateOneBlog(Blog entity);

        public Blog UpdateForOneBlog(int id);

    }
}
