namespace webcarsAPI.Dominio.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
