using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminEmployees()
        {
            return View();
        }

        public IActionResult AdminRequestLogs()
        {
            return View();
        }
    }
}
