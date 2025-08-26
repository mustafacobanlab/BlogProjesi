using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories.Contracts;
using KisiselBlogProjesi.Repositories.Extensions;
using KisiselBlogProjesi.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KisiselBlogProjesi.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RepositoryContext _context;

        public BlogRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<Blog> GettAllBlogsWithDetails(BlogRequestParameters p)
        {
            return _context.Blogs
            .ToPaginate(p.PageNumber, p.PageSize);


        }

       

        public void DeleteOneBlog(Blog blog)
        {
            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public void UpdateOneBlog(Blog blog)
        {
            if (blog == null)
                throw new ArgumentNullException(nameof(blog));

            var existingBlog = _context.Blogs.FirstOrDefault(b => b.Id == blog.Id);
            if (existingBlog == null)
                throw new InvalidOperationException("Blog bulunamadı");

            existingBlog.title = blog.title;
            existingBlog.summary = blog.summary;
            existingBlog.authorId = blog.authorId;
            existingBlog.content = blog.content;
            existingBlog.photoUrl = blog.photoUrl;

            _context.SaveChanges();
        }


        public IQueryable<Blog> GettAllBlog(bool trackChanges)
        {
            return trackChanges ? _context.Blogs : _context.Blogs.AsNoTracking();
        }

        public Blog? GetOneBlog(int id, bool trackChanges)
        {
            var blog = trackChanges
                ? _context.Blogs.FirstOrDefault(b => b.Id == id)
                : _context.Blogs.AsNoTracking().FirstOrDefault(b => b.Id == id);

            if (blog == null)
                throw new Exception($"Blog with id: {id} does not exist.");

            return blog;
        }

        public Blog? FindByCondition(Expression<Func<Blog, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Blogs.Where(expression).FirstOrDefault()
                : _context.Blogs.Where(expression).AsNoTracking().FirstOrDefault();
        }

        public Blog? GetOneBlogs(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        void IBlogRepository.CreateOneBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void Create(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }

        

        public Blog UpdateForOneBlog(int id)
        {
            return _context.Blogs.FirstOrDefault(b => b.Id == id);
        }
    }
}
