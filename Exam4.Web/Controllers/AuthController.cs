using Exam4.Web.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam4.Web.Controllers
{
    public class AuthController : Controller
    {
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(!ModelState.IsValid) return View(model);

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(user, model.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(model);
            }

            return RedirectToAction("Index","Admin");
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
            
            var result = await UserManager.CreateAsync(user,model.Password);

            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("",error.Description);
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }





    }
}
