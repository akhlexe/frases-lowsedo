using Frases_Lowsedo.Contracts.IServices;
using Frases_Lowsedo.DTOs;
using Frases_Lowsedo.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;

namespace Frases_Lowsedo.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new AuthorIndexViewModel();

            IList<AuthorDTO> authorDTOs = await authorService.GetAllAsync();
            model.Authors = authorDTOs;

            return View(model);
        }
    }
}
