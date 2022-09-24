using Frases_Lowsedo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frases_Lowsedo.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService authorService;

        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
