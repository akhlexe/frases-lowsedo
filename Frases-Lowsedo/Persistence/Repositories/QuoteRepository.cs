using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;

namespace Frases_Lowsedo.Persistence.Repositories
{
    public class QuoteRepository : GenericRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(FrasesLowsedoDBContext context) : base(context)
        {
        }

        public Task<bool> Add(Quote entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Quote entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Quote>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Quote> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Quote entity)
        {
            throw new NotImplementedException();
        }
    }
}
