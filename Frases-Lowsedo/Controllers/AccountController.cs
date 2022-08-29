using Frases_Lowsedo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Frases_Lowsedo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                IdentityResult identityResult = await userManager.CreateAsync(user, model.Password);

                if (identityResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        //public IActionResult Login(LoginViewModel model)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }


    public enum AccountActions
    {
        Register,
        RegisterAsync,
        Login,
        LogoutAsync
    }
}
