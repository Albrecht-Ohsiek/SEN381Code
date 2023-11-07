using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly IWorkRequestRepository _workRequestRepository;

        public ServiceRequestsController(IWorkRequestRepository workRequestRepository)
        {
            _workRequestRepository = workRequestRepository;
        }

        
        public async Task<IActionResult> ServiceRequests()
        {
            return View(await _workRequestRepository.GetAllWorkRequests());
        }
    }
}
