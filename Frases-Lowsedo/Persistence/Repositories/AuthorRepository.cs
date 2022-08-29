using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(
            FrasesLowsedoDBContext context
        ) : base(context)
        {
        }

        public override async Task<bool> Add(Author entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }


        public override async Task<IEnumerable<Author>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<Author>();
            }
        }


    }
}
