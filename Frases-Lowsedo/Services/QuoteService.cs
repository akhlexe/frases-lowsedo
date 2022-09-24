using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.Exceptions;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Services
{
    public class QuoteService
    {
        private readonly IUnitOfWork repository;

        public QuoteService(IUnitOfWork repository)
        {
            this.repository = repository;
        }

        public IList<QuoteDTO> GetAll()
        {
            List<Quote> quotes = repository.Quotes.AsNoTracking().ToList();

            return quotes.Select(quote => new QuoteDTO()
            {
                Id = quote.Id,
                Text = quote.Text,
                AuthorName = quote.Author.Name,
                AuthorId = quote.AuthorId,
                CreatedAt = quote.CreatedAt

            }).ToList();
        }

        public void SaveQuote(QuoteDTO quoteDTO)
        {
            if (quoteDTO == null)
            {
                throw new ArgumentNullException(nameof(quoteDTO));
            }

            Quote quote;

            if (quoteDTO.Id > 0)
            {
                quote = repository.Quotes.FirstOrDefault(q => q.Id == quoteDTO.Id)
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

            repository.Quotes.Add(quote);
            repository.SaveChanges();

        }

        public void DeleteQuote(int id)
        {
            Quote quote = repository.Quotes.FirstOrDefault(q => q.Id == id)
                ?? throw new QuoteNotFoundException($"No existe frase con Id: {id}");

            repository.Quotes.Remove(quote);
            repository.SaveChanges();
        }

        public QuoteDTO GetById(int id)
        {
            Quote quote = repository.Quotes.FirstOrDefault(q => q.Id == id)
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
