using System.Linq.Expressions;

namespace KisiselBlogProjesi.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {

        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Remove(T entity);

        void Update(T entity);

    }
}
