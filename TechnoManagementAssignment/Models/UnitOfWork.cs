using System.Collections;
using TechnoManagementAssignment.Data;

namespace TechnoManagementAssignment.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private Hashtable repositories;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories == null) repositories = new Hashtable();
            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepository<T>)repositories[type];
        }
    }
}
