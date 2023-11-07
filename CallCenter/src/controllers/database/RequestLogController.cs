using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/requestLog")]
    public class RequestLogController : ControllerBase
    {
        private readonly IRequestLogRepository _requestLogRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IClientRepository _clientRepository;

        public RequestLogController(IRequestLogRepository requestLogRepository, ITechnicianRepository technicianRepository, IEmployeeRepository employeeRepository, IClientRepository clientRepository)
        {
            _requestLogRepository = requestLogRepository;
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRequestLog([FromBody] AddRequestLogRequest requestLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            RequestLog newRequestLog = new RequestLog()
            {
                requestId = Guid.NewGuid(),
                clientId = requestLog.clientId,
                lastCallDate = requestLog.lastCallDate,
                callDuration = requestLog.callDuration,
                technicianId = requestLog.technicianId,
                priorityLevel = requestLog.priorityLevel,
                status = requestLog.status
            };

            await _requestLogRepository.AddRequestLog(newRequestLog);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRequestLog([FromBody] UpdateRequestLogRequest requestLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            RequestLog existingRequestLog = await _requestLogRepository.GetRequestLogById(requestLog.requestId);
            if (existingRequestLog == null)
            {
                return NotFound();
            }

            RequestLog newRequestLog = new RequestLog()
            {
                requestId = existingRequestLog.requestId,
                clientId = existingRequestLog.clientId,
                lastCallDate = requestLog.lastCallDate ?? existingRequestLog.lastCallDate,
                callDuration = requestLog.callDuration ?? existingRequestLog.callDuration,
                technicianId = requestLog.technicianId ?? existingRequestLog.technicianId,
                priorityLevel = requestLog.priorityLevel ?? existingRequestLog.priorityLevel,
                status = requestLog.status ?? existingRequestLog.status
            };

            await _requestLogRepository.UpdateRequestLog(newRequestLog);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRequestLogs()
        {
            List<RequestLog> requestLogs = await _requestLogRepository.GetAllRequestLogs();
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = await HydratedRequestLogs(requestLogs);

            return Ok(hydratedResponses);
        }


        [HttpGet("getby/requestId/{requestId}")]
        public async Task<IActionResult> GetRequestLogByRequestLogId([FromRoute] string requestId)
        {
            if (Guid.TryParse(requestId, out Guid result))
            {
                RequestLog requestLog = await _requestLogRepository.GetRequestLogById(result);
                if (requestLog == null)
                {
                    return NotFound();
                }

                HydratedRequestLogResponse hydratedRequestLogResponse = await HydratedRequestLog(requestLog);

                return Ok(hydratedRequestLogResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetRequestLogByClienId([FromRoute] string clientId)
        {
            if (Guid.TryParse(clientId, out Guid result))
            {
                List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogByClientId(result);
                if (requestLogs.Count < 1)
                {
                    return NotFound();
                }

                List<HydratedRequestLogResponse> hydratedResponses = await HydratedRequestLogs(requestLogs);

                return Ok(hydratedResponses);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/technicianId/{technicianId}")]
        public async Task<IActionResult> GetRequestLogByTechnicianId([FromRoute] string technicianId)
        {
            if (Guid.TryParse(technicianId, out Guid result))
            {
                List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogByTechnicianId(result);
                if (requestLogs.Count < 1)
                {
                    return NotFound();
                }

                List<HydratedRequestLogResponse> hydratedResponses = await HydratedRequestLogs(requestLogs);

                return Ok(hydratedResponses);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/status/{status}")]
        public async Task<IActionResult> GetRequestLogByStatus([FromRoute] string status)
        {

            List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogtByStatus(status);
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = await HydratedRequestLogs(requestLogs);

            return Ok(hydratedResponses);

        }

        [HttpGet("getby/priority/{priority}")]
        public async Task<IActionResult> GetRequestLogByPriority([FromRoute] string priority)
        {
            List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogtByPriority(priority);
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = await HydratedRequestLogs(requestLogs);

            return Ok(hydratedResponses);
        }

        private async Task<List<HydratedRequestLogResponse>> HydratedRequestLogs(List<RequestLog> requestLogs)
        {
            List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

            // TODO: This is going to be very slow on larger datasets, FIX
            foreach (var requestLog in requestLogs)
            {
                HydratedRequestLogResponse hydratedRequestLogResponse = await HydratedRequestLog(requestLog);

                hydratedResponses.Add(hydratedRequestLogResponse);
            }

            return hydratedResponses;
        }

        private async Task<HydratedRequestLogResponse> HydratedRequestLog(RequestLog requestLog)
        {
            Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
            Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
            Client client = await _clientRepository.GetClientById(requestLog.clientId);

            HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
            {
                requestId = requestLog.requestId,
                clientName = client.clientName,
                clientPhoneNumber = client.phoneNumber,
                lastCallDate = requestLog.lastCallDate,
                callDuration = requestLog.callDuration,
                employeeName = employee.employeeName,
                department = employee.department,
                priorityLevel = requestLog.priorityLevel,
                status = requestLog.status
            };

            return hydratedRequestLogResponse;
        }

    }
}