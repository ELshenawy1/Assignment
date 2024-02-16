using TechnoManagementAssignment.Specifications;

namespace TechnoManagementAssignment.Models
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllWithSpec(ISpecification<T> spec);
        int Count(ISpecification<T> spec);
        T GetByIDWithSpec(ISpecification<T> spec);

    }
}
