using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.AccountManagement;
using System.Security.Claims;

namespace YourProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Giriş sayfası
        }


        private bool ValidateUserWithLdap(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, "10.34.0.21"))
                {
                    return context.ValidateCredentials(username, password);
                }
            }
            catch
            {
                return false;
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            bool loginSuccess = ValidateUserWithLdap(username, password);

            if (!loginSuccess)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                return View("Index");
            }

            // Yetkili giriş yaparsa, kullanıcıyı authenticate et
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User") // istenirse dinamik çekilebilir
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home"); // Giriş sonrası yönlendirme
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
