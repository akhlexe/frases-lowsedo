using Frases_Lowsedo.Contracts.IRepositories;

namespace Frases_Lowsedo.Contracts.IConfiguration
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }

        Task CompleteAsync();
    }
}
