using Microsoft.AspNetCore.Mvc;

namespace Frases_Lowsedo.Controllers
{
    public class QuoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
