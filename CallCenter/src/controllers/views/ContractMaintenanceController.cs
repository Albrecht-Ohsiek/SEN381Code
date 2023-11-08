using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class ContractMaintenanceController : Controller 
    {
        private readonly IContractRepository _contractRepository;
        public ContractMaintenanceController(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
        public async Task<IActionResult> ContractMaintenanceContracts()
        {
            var contracts = await _contractRepository.GetAllContracts();
            return View(contracts);
        }
        
        public IActionResult ContractMaintenanceServices()
        {
            return View();
        }
    }
}