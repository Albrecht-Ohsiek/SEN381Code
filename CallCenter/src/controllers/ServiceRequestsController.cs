using CallCenter.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/ServiceRequests")]
    public class ServiceRequestsController
    {
        [HttpGet("GetWorkRequest")]
        public IActionResult GetWorkRequest()
        {
            return ServiceDepartmentHandler.GetWorkRequest();
        }

        [HttpGet("TrackRequest")]
        public IActionResult TrackRequest()
        {
            return ServiceDepartmentHandler.TrackRequest();
        }

        [HttpPost("AddRequests")]
        public IActionResult AddRequests()
        {
            return ServiceDepartmentHandler.AddRequests();
        }

        [HttpPatch("EscalateRequests")]
        public IActionResult EscalateRequests()
        {
            return ServiceDepartmentHandler.EscalateRequests();
        }

        [HttpPatch("ReassignRequests")]
        public IActionResult ReassignRequests()
        {
            return ServiceDepartmentHandler.ReassignRequests();
        }

        [HttpDelete("DeleteRequest")]
        public IActionResult DeleteRequest()
        {
            return ServiceDepartmentHandler.DeleteRequest();
        }
    }
}