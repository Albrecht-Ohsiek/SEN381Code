using CallCenter.Models;
using CallCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginServices _loginServices;

        public LoginController(LoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AddLoginRequest user)
        {
            string result = await _loginServices.AuthenticateUser(user);
            if (result == "Login Successful")
            {
                return RedirectToAction("AdminEmployees", "AdminEmployees");
            }
            else
            {
                ViewBag.ErrorMessage = result;
                return View();
            }

        }
    }
}
