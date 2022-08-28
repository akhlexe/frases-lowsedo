using Frases_Lowsedo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frases_Lowsedo.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService authorService;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {
            _logger = logger;
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
