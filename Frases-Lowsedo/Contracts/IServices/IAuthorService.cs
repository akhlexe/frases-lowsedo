using Frases_Lowsedo.DTOs;

namespace Frases_Lowsedo.Contracts.IServices
{
    public interface IAuthorService
    {
        Task<IList<AuthorDTO>> GetAllAsync();

        Task<AuthorDTO> GetByIdAsync(int id);

        Task SaveAsync(AuthorDTO authorDTO);

        Task DeleteAsync(int id);
    }
}
