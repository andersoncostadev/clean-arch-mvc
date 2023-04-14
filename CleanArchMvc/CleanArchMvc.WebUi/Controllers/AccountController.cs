using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _authenticate.Authenticate(loginViewModel.Email!, loginViewModel.Password!);

            if (result)
            {
                if(string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginViewModel.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attemp.(password must be strong)");
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authenticate.RegisterUser(model.Email!, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "invalid register attempt(password must be strong.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        } 
    }
}
