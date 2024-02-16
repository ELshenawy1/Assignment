
using Microsoft.EntityFrameworkCore;
using TechnoManagementAssignment.Data;
using TechnoManagementAssignment.Specifications;

namespace TechnoManagementAssignment.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);   
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }
        public T GetByIDWithSpec(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefault();
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public int Count(ISpecification<T> spec)
        {
            return ApplySpecification(spec).Count();
        }


        public List<T> GetAllWithSpec(ISpecification<T> spec)
        {
            return  ApplySpecification(spec).ToList();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }
    }
}
