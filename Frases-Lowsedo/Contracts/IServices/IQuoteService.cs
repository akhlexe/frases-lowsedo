using Frases_Lowsedo.DTOs;

namespace Frases_Lowsedo.Contracts.IServices
{
    public interface IQuoteService
    {
        Task<IList<QuoteDTO>> GetAllAsync();

        Task<QuoteDTO> GetByIdAsync(int id);

        Task SaveAsync(QuoteDTO quoteDTO);

        Task DeleteAsync(int id);
    }
}
