using System.Diagnostics;
using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories.Contracts;
using KisiselBlogProjesi.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace KisiselBlogProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepositoryManager _repositoryManager;

        public HomeController(ILogger<HomeController> logger,IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index(BlogRequestParameters p)
        {
            var allBlogs = _repositoryManager.Blog.GettAllBlog(false)
                .OrderByDescending(b => b.Id);

            var blogs = allBlogs
                .Skip((p.PageNumber - 1) * p.PageSize)
                .Take(p.PageSize)
                .ToList();

            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = allBlogs.Count()
            };

            var model = new BlogListViewModel()
            {
                Blogs = blogs,
                Pagination = pagination
            };

            return View(model);

        }

        public IActionResult Details([FromRoute(Name = "Id")] int id)
        {
            var model = _repositoryManager.Blog.GetOneBlog(id, false);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult iletisim()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> iletisim([FromForm] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                _repositoryManager.Iletisim.CreateOneIletisim(iletisim);
                return RedirectToAction("Index");
                
                

            }

            return View(iletisim);
        }


    }
}
