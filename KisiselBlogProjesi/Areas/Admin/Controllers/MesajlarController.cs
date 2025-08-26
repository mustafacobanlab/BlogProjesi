using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories;
using KisiselBlogProjesi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KisiselBlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MesajlarController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public MesajlarController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index()
        {
            var mesajlar = _repositoryManager.Iletisim.GettAllIletisim(false).OrderByDescending(b => b.Id);

            return View(mesajlar);
        }



        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var mesaj = _repositoryManager.Iletisim.GetOneIletisim(id, false);
            if (mesaj == null)
                return NotFound();

            _repositoryManager.Iletisim.DeleteOneIletisim(mesaj);
            return RedirectToAction("Index");
        }
    }
}
