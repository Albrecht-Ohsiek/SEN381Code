using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class ClientMaintenanceController : Controller
    {
        public IActionResult ClientMaintenance()
        {
            return View();
        }
    }
}
