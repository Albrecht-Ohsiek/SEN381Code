using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using CallCenter.Types;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/call")]
    public class CallController : ControllerBase
    {
        private readonly ICallRepository _callRepository;

        public CallController(ICallRepository callRepository)
        {
            _callRepository = callRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCall([FromBody] AddCallRequest call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Call newCall = new Call()
            {
                callId = Guid.NewGuid(),
                clientId = call.ClientId,
                employeeId = call.EmployeeId,
                workId = call.WorkId,
                startTime = DateTime.Now,
                endTime = null,
            };

            await _callRepository.AddCall(newCall);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCall([FromBody] UpdateCallRequest call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Call existingCall = await _callRepository.SelectCallsById(call.CallId);

            Call newCall = new Call()
            {
                callId = existingCall.callId,
                clientId = call.ClientId ?? existingCall.clientId,
                employeeId = call.EmployeeId ?? existingCall.employeeId,
                workId = call.WorkId ?? existingCall.workId,
                startTime = existingCall.startTime,
                endTime = call.EndTime,
            };

            await _callRepository.UpdateCall(newCall);
            return Ok();
        }

        [HttpGet("getby/callId/{callId}")]
        public async Task<IActionResult> GetCallByCallId([FromRoute] string callId)
        {
            if (Guid.TryParse(callId, out Guid result))
            {
                Call call = await _callRepository.SelectCallsById(result);
                if (call == null)
                {
                    return NotFound();
                }
                return Ok(call);
            }
            else{
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetCallByCallClientId([FromRoute] string clientId)
        {
            if (Guid.TryParse(clientId, out Guid result))
            {
                List<Call> calls = await _callRepository.SelectCallsByClientId(result);
                if (calls == null)
                {
                    return NotFound();
                }
                return Ok(calls);
            }
            else{
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/workId/{workId}")]
        public async Task<IActionResult> GetCallByCallWorkId([FromRoute] string workId)
        {
            if (Guid.TryParse(workId, out Guid result))
            {
                List<Call> calls = await _callRepository.SelectCallsByWorkId(result);
                if (calls == null)
                {
                    return NotFound();
                }
                return Ok(calls);
            }
            else{
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

    }
}