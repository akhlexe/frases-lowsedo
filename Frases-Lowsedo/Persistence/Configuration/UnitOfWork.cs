using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.Contracts.IRepositories;
using Frases_Lowsedo.Model;
using Frases_Lowsedo.Persistence.Repositories;

namespace Frases_Lowsedo.Persistence.Configuration
{
    /// <summary>
    /// Esta es la clase que será inyectada en todos los controllers, a modo de DAOFactory.
    /// </summary>

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FrasesLowsedoDBContext _context;
        private readonly ILogger _logger;
        public IAuthorRepository Authors { get; private set; }

        public UnitOfWork(
            FrasesLowsedoDBContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Authors = new AuthorRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
