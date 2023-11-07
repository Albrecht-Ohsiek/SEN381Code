using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/work")]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository _workRepository;

        public WorkController(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWork([FromBody] AddWorkRequest work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Work newWork = new Work()
            {
                workId = Guid.NewGuid(),
                technicianId = work.technicianId,
                workDate = work.workDate,
            };

            await _workRepository.AddWork(newWork);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateWork([FromBody] UpdateWorkRequest work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Work existingWork = await _workRepository.GetWorkById(work.workId);
            if (existingWork == null)
            {
                return NotFound();
            }

            Work newWork = new Work()
            {
                workId = existingWork.workId,
                technicianId = work.technicianId ?? existingWork.technicianId,
                workDate = work.workDate ?? existingWork.workDate,
            };

            await _workRepository.UpdateWork(newWork);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetWorks()
        {
            List<Work> works = await _workRepository.GetAllWorks();
            if (works == null)
            {
                return NotFound();
            }
            return Ok(works);
        }

        [HttpGet("getby/workId/{workId}")]
        public async Task<IActionResult> GetWorkByWorkId([FromRoute] string workId)
        {
            if (Guid.TryParse(workId, out Guid result))
            {
                Work work = await _workRepository.GetWorkById(result);
                if (work == null)
                {
                    return NotFound();
                }
                return Ok(work);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/technicianId/{technicianId}")]
        public async Task<IActionResult> GetWorkByTechnicianId([FromRoute] string technicianId)
        {
            if (Guid.TryParse(technicianId, out Guid result))
            {
                Work work = await _workRepository.GetWorkById(result);
                if (work == null)
                {
                    return NotFound();
                }
                return Ok(work);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }
    }
}
