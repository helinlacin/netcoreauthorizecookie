using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace netcoreauthorizecookie.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login()
        {
            //kontrol edilecek verileri alıp kontrol etmemiz lazım.
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Helin Laçin"),
            new Claim(ClaimTypes.Role, "Admin")
            };
        
            var claimsIdentity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
           await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
            //home controllerde indexe git.
            return RedirectToAction("Index","Home");   
        }
    }

}



