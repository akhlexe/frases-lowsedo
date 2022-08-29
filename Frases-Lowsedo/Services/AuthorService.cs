using Frases_Lowsedo.Contracts.IConfiguration;
using Frases_Lowsedo.Contracts.IServices;
using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.Exceptions;
using Frases_Lowsedo.Model;

namespace Frases_Lowsedo.Services
{
    public class IAuthorService : Contracts.IServices.IAuthorService
    {
        private readonly IUnitOfWork _repository;

        public IAuthorService(IUnitOfWork repository)
        {
            this._repository = repository;
        }

        public async Task<IList<AuthorDTO>> GetAllAsync()
        {
            IEnumerable<Author> authors = await _repository.Authors.GetAll();

            List<AuthorDTO> dto = authors.Select(a => new AuthorDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return dto;
        }

        public async Task<AuthorDTO> GetByIdAsync(int id)
        {
            Author author = await _repository.Authors.GetById(id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task SaveAuthorAsync(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
            {
                throw new ArgumentNullException(nameof(authorDTO));
            }

            Author author;

            if (authorDTO.Id > 0)
            {
                author = await _repository.Authors.GetById(authorDTO.Id)
                    ?? throw new AuthorNotFoundException($"El autor con Id: {authorDTO.Id} no existe en la base de datos.");
            }
            else
            {
                author = new Author();
                author.CreatedAt = DateTime.Now;
            }

            author.Name = authorDTO.Name;

            await _repository.Authors.Add(author);
            await _repository.CompleteAsync();
        }


        public async Task DeleteAuthorAsync(int id)
        {
            Author author = await _repository.Authors.GetById(id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            await _repository.Authors.Delete(author);
            await _repository.CompleteAsync();
        }
    }
}
