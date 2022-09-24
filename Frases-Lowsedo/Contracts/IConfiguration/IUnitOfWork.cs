using Frases_Lowsedo.Contracts.IRepositories;

namespace Frases_Lowsedo.Contracts.IConfiguration
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IQuoteRepository Quotes { get; }

        Task CompleteAsync();
    }
}
