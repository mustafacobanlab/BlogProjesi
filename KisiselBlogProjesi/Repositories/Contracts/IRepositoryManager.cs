namespace KisiselBlogProjesi.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }

        IIletisimRepository Iletisim { get; }
       


        void Save();
    }
}
