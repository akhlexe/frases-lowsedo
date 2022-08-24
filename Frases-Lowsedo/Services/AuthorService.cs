using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.Exceptions;
using Frases_Lowsedo.Model;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Services
{
    public class AuthorService
    {
        private readonly FrasesLowsedoDBContext repository;

        public AuthorService(FrasesLowsedoDBContext repository)
        {
            this.repository = repository;
        }

        public IList<AuthorDTO> GetAll()
        {
            List<Author> authors = repository.Authors.AsNoTracking().ToList();

            List<AuthorDTO> dto = authors.Select(a => new AuthorDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return dto;
        }

        public AuthorDTO GetById(int id)
        {
            Author author = repository.Authors.FirstOrDefault(a => a.Id == id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public void SaveAuthor(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
            {
                throw new ArgumentNullException(nameof(authorDTO));
            }

            Author author;

            if (authorDTO.Id > 0)
            {
                author = repository.Authors.FirstOrDefault(a => a.Id == authorDTO.Id)
                    ?? throw new AuthorNotFoundException($"El autor con Id: {authorDTO.Id} no existe en la base de datos.");
            }
            else
            {
                author = new Author();
            }

            author.Name = authorDTO.Name;

            repository.Authors.Add(author);
            repository.SaveChanges();
        }


        public void DeleteAuthor(int id)
        {
            Author author = repository.Authors.FirstOrDefault(a => a.Id == id)
                ?? throw new AuthorNotFoundException($"El autor con Id: {id} no existe en la base de datos.");

            repository.Authors.Remove(author);
        }
    }
}
