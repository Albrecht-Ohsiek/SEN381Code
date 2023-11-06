using CallCenter.Controllers;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly WorkRequestRepository _workRequestRepository;

        public ServiceRequestsController(WorkRequestRepository workRequestRepository)
        {
            _workRequestRepository = workRequestRepository;
        }

        
        public async Task<IActionResult> ServiceRequests()
        {
            return View(await _workRequestRepository.GetAllWorkRequests());
        }
    }
}
