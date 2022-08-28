namespace Frases_Lowsedo.Contracts.IRepositories
{

    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
