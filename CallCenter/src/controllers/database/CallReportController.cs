using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/callReport")]
    public class CallReportController : ControllerBase
    {
        private readonly ICallReportRepository _callReportRepository;

        public CallReportController(ICallReportRepository callReportRepository)
        {
            _callReportRepository = callReportRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCallReport([FromBody] AddCallReportRequest call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            CallReport newCallReport = new CallReport()
            {
                callReportId = Guid.NewGuid(),
                workId = call.workId,
                calls = call.calls,
            };

            await _callReportRepository.AddCallReport(newCallReport);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCallReport([FromBody] UpdateCallReportRequest call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            CallReport existingCallReport = await _callReportRepository.GetCallReportsByCallReportId(call.callReportId);
            if (existingCallReport == null)
            {
                return NotFound();
            }

            CallReport newCallReport = new CallReport()
            {
                callReportId = existingCallReport.callReportId,
                workId = existingCallReport.workId,
                calls = call.calls ?? existingCallReport.calls,
            };

            await _callReportRepository.UpdateCallReport(newCallReport);
            return Ok();
        }

        [HttpGet("getby/reportId/{reportId}")]
        public async Task<IActionResult> GetCallReportByCallReportId([FromRoute] string reportId)
        {
            if (Guid.TryParse(reportId, out Guid result))
            {
                CallReport callReport = await _callReportRepository.GetCallReportsByCallReportId(result);
                if (callReport == null)
                {
                    return NotFound();
                }
                return Ok(callReport);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCallReports()
        {
            List<CallReport> callReports = await _callReportRepository.GetCallReports();
            if (callReports == null)
            {
                return NotFound();
            }
            return Ok(callReports);
        }

    }
}
