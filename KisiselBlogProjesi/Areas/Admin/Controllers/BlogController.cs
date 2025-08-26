using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories.Contracts;
using KisiselBlogProjesi.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Ganss.Xss;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KisiselBlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public BlogController(IRepositoryManager repositoryManager)
        {
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


        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Blog blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(ext))
                    {
                        ModelState.AddModelError("", "Sadece resim dosyaları yükleyebilirsiniz.");
                        return View(blog);
                    }

                    var fileName = Guid.NewGuid().ToString() + ext;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    blog.photoUrl = "/images/" + fileName;
                }

               

                _repositoryManager.Blog.CreateOneBlog(blog);
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            var file = Request.Form.Files.FirstOrDefault(); 
            if (file != null && file.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var ext = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(ext))
                    return Json(new { uploaded = false, error = new { message = "Sadece resim dosyaları yükleyebilirsiniz." } });

                var fileName = Guid.NewGuid().ToString() + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var url = "/images/" + fileName;
                return Json(new { uploaded = true, url });
            }

            return Json(new { uploaded = false, error = new { message = "Dosya bulunamadı." } });
        }

        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var blog = _repositoryManager.Blog.GetOneBlog(id, false);
            if (blog == null)
                return NotFound();

            _repositoryManager.Blog.DeleteOneBlog(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _repositoryManager.Blog.UpdateForOneBlog(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Blog blog, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(ext))
                    {
                        ModelState.AddModelError("", "Sadece resim dosyaları yükleyebilirsiniz.");
                        return View(blog);
                    }

                    var fileName = Guid.NewGuid().ToString() + ext;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    blog.photoUrl = "/images/" + fileName;
                }

               

                _repositoryManager.Blog.UpdateOneBlog(blog);
                return RedirectToAction("Index");
            }

            return View(blog);
        }


    }
}
