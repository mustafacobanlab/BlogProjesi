using KisiselBlogProjesi.Models;
using KisiselBlogProjesi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KisiselBlogProjesi.Repositories
{
    public class IletisimRepository : IIletisimRepository
    {

        private readonly RepositoryContext _context;



        public IletisimRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IQueryable<Iletisim> GettAllIletisim(bool trackChanges)
        {
            return trackChanges ? _context.Iletisims : _context.Iletisims.AsNoTracking();
        }



        public void Create(Iletisim entity)
        {
            throw new NotImplementedException();
        }

        public Iletisim? FindByCondition(Expression<Func<Iletisim, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Remove(Iletisim entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Iletisim entity)
        {
            throw new NotImplementedException();
        }

        void IIletisimRepository.CreateOneIletisim(Iletisim iletisim)
        {
            _context.Iletisims.Add(iletisim);
            _context.SaveChanges();
        }

        public Iletisim? GetOneIletisms(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Iletisim? GetOneIletisim(int id, bool trackChanges)
        {
            var iletisim = trackChanges
                ? _context.Iletisims.FirstOrDefault(b => b.Id == id)
                : _context.Iletisims.AsNoTracking().FirstOrDefault(b => b.Id == id);

            if (iletisim == null)
                throw new Exception($"Iletisim with id: {id} does not exist.");

            return iletisim;
        }

        public void DeleteOneIletisim(Iletisim iletisim)
        {
            if (iletisim == null)
                throw new ArgumentNullException(nameof(iletisim));

            _context.Iletisims.Remove(iletisim);
            _context.SaveChanges();
        }
    }
}
