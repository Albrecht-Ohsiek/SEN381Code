using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminController : Controller
    {
        private readonly IRequestLogRepository _requestLogRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IClientRepository _clientRepository;

        public AdminController(IRequestLogRepository requestLogRepository, ITechnicianRepository technicianRepository, IEmployeeRepository employeeRepository, IClientRepository clientRepository)
        {
            _requestLogRepository = requestLogRepository;
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        
        public async Task<IActionResult> AdminEmployees()
        {
            return View(await _employeeRepository.GetAllEmployees());
        }

        public async Task<IActionResult> AdminRequestLogs()
        {
            return View(await _technicianRepository.GetAllTechnicians());
        }
    }
}
