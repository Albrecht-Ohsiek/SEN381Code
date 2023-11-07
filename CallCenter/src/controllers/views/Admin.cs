using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminController : Controller
    {
        private readonly RequestLogRepository _requestLogRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TechnicianRepository _technicianRepository;

        public AdminController(RequestLogRepository requestLogRepository, TechnicianRepository technicianRepository, EmployeeRepository employeeRepository, ClientRepository clientRepository)
        {
            _requestLogRepository = requestLogRepository;
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
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
