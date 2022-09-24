using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.Contracts.IServices;
using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.Exceptions;
using Frases_Lowsedo.Model;

namespace Frases_Lowsedo.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork repository;

        public AuthorService(IUnitOfWork repository)
        {
            this.repository = repository;
        }

        public async Task<IList<AuthorDTO>> GetAllAsync()
        {
            IEnumerable<Author> authors = await repository.Authors.GetAll();

            List<AuthorDTO> dto = authors.Select(a => new AuthorDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return dto;
        }

        public async Task<AuthorDTO> GetByIdAsync(int id)
        {
            Author author = await repository.Authors.GetById(id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task SaveAsync(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
            {
                throw new ArgumentNullException(nameof(authorDTO));
            }

            Author author;

            if (authorDTO.Id > 0)
            {
                author = await repository.Authors.GetById(authorDTO.Id)
                    ?? throw new AuthorNotFoundException($"El autor con Id: {authorDTO.Id} no existe en la base de datos.");
            }
            else
            {
                author = new Author();
                author.CreatedAt = DateTime.Now;
            }

            author.Name = authorDTO.Name;

            await repository.Authors.Add(author);
            await repository.CompleteAsync();
        }


        public async Task DeleteAsync(int id)
        {
            Author author = await repository.Authors.GetById(id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            await repository.Authors.Delete(author);
            await repository.CompleteAsync();
        }
    }
}
