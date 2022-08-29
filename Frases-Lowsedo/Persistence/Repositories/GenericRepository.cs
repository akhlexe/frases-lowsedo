using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Persistence.Repositories
{
    /// <summary>
    /// Repositorio genérico para todos los demás repositorios.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected FrasesLowsedoDBContext _context;
        protected DbSet<T> dbSet;

        public GenericRepository(FrasesLowsedoDBContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
