using KisiselBlogProjesi.Repositories.Contracts;

namespace KisiselBlogProjesi.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IBlogRepository _blogRepository;

        private readonly IIletisimRepository _iletisimRepository;


        public RepositoryManager(RepositoryContext context, IBlogRepository blogRepository, IIletisimRepository iletisimRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _iletisimRepository = iletisimRepository;
        }

        public IBlogRepository Blog => _blogRepository;

        public IIletisimRepository Iletisim => _iletisimRepository;


        



        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
