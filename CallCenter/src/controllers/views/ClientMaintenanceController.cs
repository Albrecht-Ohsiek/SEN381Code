using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class ClientMaintenanceController : Controller 
    {
        private readonly IClientRepository _clientRepository;
        public ClientMaintenanceController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> ClientMaintenance()
        {
            return View(await _clientRepository.GetAllClients());
        }

        // GET: Employee/Details/?
        public async Task<IActionResult> ClientDetails(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public async Task<IActionResult> ClientEdit()
        {
            return View(await _clientRepository.GetAllClients());
        }
    }
}