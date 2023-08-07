using CST350_Milestone1.Models;
using CST350_Milestone1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST350_Milestone1.Controllers
{
    public class RegistrationController : Controller
    {
        //Views/Registration/Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        //ProcessRegisterNewUser method used by Views/Registration/Index.cshtml -> <form asp-action="ProcessRegisterNewUser">
        public IActionResult ProcessRegisterNewUser(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.AddNewUser(user))
                return View("RegistrationSuccess", user);
            else 
                return View("RegistrationFailure", user);
        }
    }
}
