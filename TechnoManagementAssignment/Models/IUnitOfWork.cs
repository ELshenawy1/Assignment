namespace TechnoManagementAssignment.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        int Complete();
    }
}
