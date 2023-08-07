using CST350_Milestone1.Models;
using CST350_Milestone1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350_Milestone1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //ProcessLogin method used by Views/Login/Index.cshtml -> <form asp-action="ProcessLogin">
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
                return View("LoginSuccess", user);
            else
                return View("LoginFailure", user);

        }
    }
}
