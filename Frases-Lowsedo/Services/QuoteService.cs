using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.Contracts.IServices;
using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.Exceptions;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IUnitOfWork repository;

        public QuoteService(IUnitOfWork repository)
        {
            this.repository = repository;
        }

        public async Task<IList<QuoteDTO>> GetAllAsync()
        {
            IEnumerable<Quote> quotes = await repository.Quotes.GetAll();

            return quotes.Select(quote => new QuoteDTO()
            {
                Id = quote.Id,
                Text = quote.Text,
                AuthorName = quote.Author.Name,
                AuthorId = quote.AuthorId,
                CreatedAt = quote.CreatedAt

            }).ToList();
        }

        public async Task SaveAsync(QuoteDTO quoteDTO)
        {
            if (quoteDTO == null)
            {
                throw new ArgumentNullException(nameof(quoteDTO));
            }

            Quote quote;

            if (quoteDTO.Id > 0)
            {
                quote = await repository.Quotes.GetById(quoteDTO.Id)
                    ?? throw new QuoteNotFoundException($"No existe frase con Id: {quoteDTO.Id}");
            }
            else
            {
                quote = new Quote();
                quote.Author = new Author();
            }

            quote.Text = quoteDTO.Text;
            quote.Author.Name = quoteDTO.AuthorName;
            quote.CreatedAt = DateTime.Now;

            await repository.Quotes.Add(quote);
            await repository.CompleteAsync();

        }

        public async Task DeleteAsync(int id)
        {
            Quote quote = await repository.Quotes.GetById(id)
                ?? throw new QuoteNotFoundException($"No existe frase con Id: {id}");

            await repository.Quotes.Delete(quote);
            await repository.CompleteAsync();
        }

        public async Task<QuoteDTO> GetByIdAsync(int id)
        {
            Quote quote = await repository.Quotes.GetById(id)
                ?? throw new QuoteNotFoundException($"No existe frase con Id: {id}");

            return new QuoteDTO()
            {
                Id = quote.Id,
                Text = quote.Text,
                AuthorName = quote.Author.Name,
                AuthorId = quote.AuthorId,
                CreatedAt = quote.CreatedAt,
            };
        }
    }
}
