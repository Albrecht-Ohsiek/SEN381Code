using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class ServiceRequestsController : Controller
    {
        public IActionResult ServiceRequests()
        {
            return View();
        }
    }
}
