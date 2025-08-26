using KisiselBlogProjesi.Models;

namespace KisiselBlogProjesi.Repositories.Contracts
{
    public interface IIletisimRepository : IRepositoryBase<Iletisim>
    {

        IQueryable<Iletisim> GettAllIletisim(bool trackChanges);


        public void DeleteOneIletisim(Iletisim iletisim);
        Iletisim? GetOneIletisms(int id, bool trackChanges);
        Iletisim? GetOneIletisim(int id, bool trackChanges);
        void CreateOneIletisim(Iletisim iletisim);
    }
}