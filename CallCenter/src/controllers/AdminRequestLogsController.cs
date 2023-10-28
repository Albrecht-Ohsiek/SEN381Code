using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminRequestLogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
