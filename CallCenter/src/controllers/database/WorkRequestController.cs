using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/workRequest")]
    public class WorkRequestController : ControllerBase
    {
        private readonly IWorkRequestRepository _workRequestRepository;

        public WorkRequestController(IWorkRequestRepository workRequestRepository)
        {
            _workRequestRepository = workRequestRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWorkRequest([FromBody] AddWorkRequestRequest workRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            WorkRequest newWorkRequest = new WorkRequest()
            {
                requestId = Guid.NewGuid(),
                clientId = workRequest.clientId,
                serviceType = workRequest.serviceType,
                priority = workRequest.priority,
                status = workRequest.status
            };

            await _workRequestRepository.AddWorkRequest(newWorkRequest);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateWorkRequest([FromBody] UpdateWorkRequestRequest workRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            WorkRequest existingWorkRequest = await _workRequestRepository.GetWorkRequestById(workRequest.requestId);
            if (existingWorkRequest == null)
            {
                return NotFound();
            }

            WorkRequest newWorkRequest = new WorkRequest()
            {
                requestId = existingWorkRequest.requestId,
                clientId = existingWorkRequest.clientId,
                serviceType = workRequest.serviceType ?? existingWorkRequest.serviceType,
                priority = workRequest.priority ?? existingWorkRequest.priority,
                status = workRequest.status ?? existingWorkRequest.status
            };

            await _workRequestRepository.UpdateWorkRequest(newWorkRequest);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetWorkRequests()
        {
            List<WorkRequest> workRequests = await _workRequestRepository.GetAllWorkRequests();
            if (workRequests == null)
            {
                return NotFound();
            }
            return Ok(workRequests);
        }

        [HttpGet("getby/requestId/{requestId}")]
        public async Task<IActionResult> GetWorkRequestByWorkRequestId([FromRoute] string requestId)
        {
            if (Guid.TryParse(requestId, out Guid result))
            {
                WorkRequest workRequest = await _workRequestRepository.GetWorkRequestById(result);
                if (workRequest == null)
                {
                    return NotFound();
                }
                return Ok(workRequest);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetWorkRequestByWorkClientId([FromRoute] string clientId)
        {
            if (Guid.TryParse(clientId, out Guid result))
            {
                WorkRequest workRequest = await _workRequestRepository.GetWorkRequestById(result);
                if (workRequest == null)
                {
                    return NotFound();
                }
                return Ok(workRequest);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/priority/{priority}")]
        public async Task<IActionResult> GetWorkRequestByPriority([FromRoute] string priority)
        {
            List<WorkRequest> workRequest = await _workRequestRepository.GetWorkRequestByPriority(priority);
            if (workRequest == null)
            {
                return NotFound();
            }
            return Ok(workRequest);
        }

        [HttpGet("getby/serviceType/{serviceType}")]
        public async Task<IActionResult> GetWorkRequestByServiceType([FromRoute] string serviceType)
        {
            List<WorkRequest> workRequest = await _workRequestRepository.GetWorkRequestByServiceType(serviceType);
            if (workRequest == null)
            {
                return NotFound();
            }
            return Ok(workRequest);
        }

        [HttpGet("getby/status/{status}")]
        public async Task<IActionResult> GetWorkRequestByStatus([FromRoute] string status)
        {
            List<WorkRequest> workRequest = await _workRequestRepository.GetWorkRequestByStatus(status);
            if (workRequest == null)
            {
                return NotFound();
            }
            return Ok(workRequest);
        }
    }
}
