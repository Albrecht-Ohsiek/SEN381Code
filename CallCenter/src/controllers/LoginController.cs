using CallCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            LoginServices login = new LoginServices();
            string result = login.AuthenticateUser(username, password);
            if (result == "Logged in successfully.")
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
