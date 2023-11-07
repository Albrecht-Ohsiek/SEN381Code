using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class ContractMaintenanceController : Controller 
    {
        public IActionResult ContractMaintenanceContracts()
        {
            return View();
        }
        
        public IActionResult ContractMaintenanceServices()
        {
            return View();
        }
    }
}