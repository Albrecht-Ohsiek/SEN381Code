using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/technician")]
    public class TechnicianController : ControllerBase
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TechnicianController(ITechnicianRepository technicianRepository, IEmployeeRepository employeeRepository)
        {
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTechnician([FromBody] AddTechnicianRequest technician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Technician newTechnician = new Technician()
            {
                technicianId = Guid.NewGuid(),
                employeeId = technician.employeeId,
                skillLevel = technician.skillLevel,
                availability = technician.availability,
                serviceArea = technician.serviceArea,
                certificationLevel = technician.certificationLevel
            };

            await _technicianRepository.AddTechnician(newTechnician);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTechnician([FromBody] UpdateTechnicianRequest technician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Technician existingTechnician = await _technicianRepository.GetTechnicianById(technician.technicianId);

            Technician newTechnician = new Technician()
            {
                technicianId = technician.technicianId,
                employeeId = existingTechnician.employeeId,
                skillLevel = technician.skillLevel ?? existingTechnician.skillLevel,
                availability = technician.availability ?? existingTechnician.availability,
                serviceArea = technician.serviceArea ?? existingTechnician.serviceArea,
                certificationLevel = technician.certificationLevel ?? existingTechnician.certificationLevel
            };

            await _technicianRepository.UpdateTechnician(newTechnician);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetTechnicians()
        {
            List<Technician> technicians = await _technicianRepository.GetAllTechnicians();
            if (technicians.Count < 1)
            {
                return NotFound();
            }
            List<HydratedTechnicianResponse> hydratedResponses = await HydrateTechnicians(technicians);

            return Ok(hydratedResponses);
        }

        [HttpGet("getby/technicianId/{technicianId}")]
        public async Task<IActionResult> GetTechnicianByTechnicianId([FromRoute] string technicianId)
        {
            if (Guid.TryParse(technicianId, out Guid result))
            {
                Technician technician = await _technicianRepository.GetTechnicianById(result);
                if (technician == null)
                {
                    return NotFound();
                }

                HydratedTechnicianResponse hydratedTechnicianResponse = await HydratedTechnician(technician);
                return Ok(hydratedTechnicianResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/employeeId/{employeeId}")]
        public async Task<IActionResult> GetTechnicianByEmployeeId([FromRoute] string employeeId)
        {
            if (Guid.TryParse(employeeId, out Guid result))
            {
                Technician technician = await _technicianRepository.GetTechnicianByEmployeeId(result);
                if (technician == null)
                {
                    return NotFound();
                }

                HydratedTechnicianResponse hydratedTechnicianResponse = await HydratedTechnician(technician);
                return Ok(hydratedTechnicianResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/skillLevel/{skillLevel}")]
        public async Task<IActionResult> GetTechnicianBySkillLevel([FromRoute] int skillLevel)
        {
            List<Technician> technicians = await _technicianRepository.GetTechnicianBySkillLevel(skillLevel);
            if (technicians.Count < 1)
            {
                return NotFound();
            }

            List<HydratedTechnicianResponse> hydratedTechnicianResponse = await HydrateTechnicians(technicians);
            return Ok(hydratedTechnicianResponse);
        }

        [HttpGet("getby/serviceArea/{serviceArea}")]
        public async Task<IActionResult> GetTechnicianByServiceArea([FromRoute] string serviceArea)
        {
            List<Technician> technicians = await _technicianRepository.GetTechnicianByServiceArea(serviceArea);
            if (technicians.Count < 1)
            {
                return NotFound();
            }

            List<HydratedTechnicianResponse> hydratedTechnicianResponse = await HydrateTechnicians(technicians);
            return Ok(hydratedTechnicianResponse);
        }

        [HttpGet("getby/availability/{availability}")]
        public async Task<IActionResult> GetTechnicianByAvailability([FromRoute] string availability)
        {
            List<Technician> technicians = await _technicianRepository.GetTechnicianByServiceArea(availability);
            if (technicians.Count < 1)
            {
                return NotFound();
            }

            List<HydratedTechnicianResponse> hydratedTechnicianResponse = await HydrateTechnicians(technicians);
            return Ok(hydratedTechnicianResponse);
        }

        [HttpGet("getby/certificationLevel/{certificationLevel}")]
        public async Task<IActionResult> GetTechnicianByCertificationLevel([FromRoute] string certificationLevel)
        {
            List<Technician> technicians = await _technicianRepository.GetTechnicianByCertificationLevel(certificationLevel);
            if (technicians.Count < 1)
            {
                return NotFound();
            }

            List<HydratedTechnicianResponse> hydratedTechnicianResponse = await HydrateTechnicians(technicians);
            return Ok(hydratedTechnicianResponse);
        }

        private async Task<List<HydratedTechnicianResponse>> HydrateTechnicians(List<Technician> technicians)
        {
            List<HydratedTechnicianResponse> hydratedResponses = new List<HydratedTechnicianResponse>();

            // TODO: This is going to be very slow on larger datasets, FIX
            foreach (var technician in technicians)
            {
                HydratedTechnicianResponse hydratedTechnicianResponse = await HydratedTechnician(technician);

                hydratedResponses.Add(hydratedTechnicianResponse);
            }

            return hydratedResponses;
        }

        private async Task<HydratedTechnicianResponse> HydratedTechnician(Technician technician)
        {
            Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);

            HydratedTechnicianResponse hydratedTechnicianResponse = new HydratedTechnicianResponse()
            {
                technicianId = technician.technicianId,
                employeeName = employee.employeeName,
                phoneNumber = employee.phoneNumber,
                email = employee.emailAddress,
                skillLevel = technician.skillLevel,
                availability = technician.availability,
                serviceArea = technician.serviceArea,
                certificationLevel = technician.certificationLevel,
            };

            return hydratedTechnicianResponse;
        }
    }
}
