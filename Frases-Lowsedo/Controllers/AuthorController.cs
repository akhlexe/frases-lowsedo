using Frases_Lowsedo.Services;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
