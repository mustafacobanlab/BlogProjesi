using KisiselBlogProjesi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KisiselBlogProjesi.Components
{
    public class IletisimSummaryViewComponent : ViewComponent
    {
        private readonly IRepositoryManager _repositoryManager;

        public IletisimSummaryViewComponent(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public string Invoke()
        {
            return _repositoryManager.Iletisim.GettAllIletisim(false).Count().ToString();
        }

    }
}
