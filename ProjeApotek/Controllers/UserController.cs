using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjeApotek.Models;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace ProjeApotek.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string returnUrl = "")
        {
            @ViewData["ReturnUrl"] = returnUrl;
            return View();
           
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel, string returnUrl="")
        {
            //Kontrollera inloggningen
            bool validUser = CheckUser(userModel);
             if (validUser==true)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userModel.UserName));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                if (returnUrl != "")
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Order");
            
            }
            else 
            {
                ViewBag.ErrorMessage = "Inlogningen är inte godkänd";
                @ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
            
        }
        private bool CheckUser(UserModel userModel)
        {
            //Hard coded. ToDo check in database
            if (userModel.UserName=="admine" && userModel.Password == "pwd")
                return true;

            else
                return false;
        }
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
