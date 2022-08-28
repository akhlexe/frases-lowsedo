using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(
            FrasesLowsedoDBContext context,
            ILogger logger
        ) : base(context, logger)
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
                _logger.LogError(ex, "{Repo} Add method error", typeof(AuthorRepository));
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

                _logger.LogError(ex, "{Repo} All method error", typeof(AuthorRepository));
                return new List<Author>();
            }
        }


    }
}
