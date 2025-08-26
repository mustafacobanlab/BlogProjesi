using KisiselBlogProjesi.Models;

namespace KisiselBlogProjesi.Repositories.Extensions
{
    public static class BlogRepositoryExtension
    {
        public static IQueryable<Blog> ToPaginate(this IQueryable<Blog> blogs, int pageNumber, int pageSize)
        {
            return blogs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

        }
    }
}
