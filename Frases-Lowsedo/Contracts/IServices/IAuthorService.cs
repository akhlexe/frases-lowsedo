using Frases_Lowsedo.DTOs;

namespace Frases_Lowsedo.Contracts.IServices
{
    public interface IAuthorService
    {
        Task<IList<AuthorDTO>> GetAllAsync();

        Task<AuthorDTO> GetByIdAsync(int id);

        Task SaveAuthorAsync(AuthorDTO authorDTO);

        Task DeleteAuthorAsync(int id);
    }
}
