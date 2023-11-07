using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Employee newEmployee = new Employee()
            {
                employeeId = Guid.NewGuid(),
                employeeName = employee.employeeName,
                department = employee.department,
                emailAddress = employee.emailAddress,
                phoneNumber = employee.phoneNumber
            };

            await _employeeRepository.AddEmployee(newEmployee);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Employee existingEmployee = await _employeeRepository.GetEmployeeById(employee.employeeId);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            Employee newEmployee = new Employee()
            {
                employeeId = existingEmployee.employeeId,
                employeeName = employee.employeeName ?? existingEmployee.employeeName,
                department = employee.department ?? existingEmployee.department,
                emailAddress = employee.emailAddress ?? existingEmployee.emailAddress,
                phoneNumber = employee.phoneNumber ?? existingEmployee.phoneNumber,
            };

            await _employeeRepository.UpdateEmployee(newEmployee);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetEmployees()
        {
            List<Employee> employees = await _employeeRepository.GetAllEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("getby/employeeId/{employeeId}")]
        public async Task<IActionResult> GetEmployeeByEmployeeId([FromRoute] string employeeId)
        {
            if (Guid.TryParse(employeeId, out Guid result))
            {
                Employee employee = await _employeeRepository.GetEmployeeById(result);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/employeeName/{employeeName}")]
        public async Task<IActionResult> GetEmployeeByClientId([FromRoute] string employeeName)
        {
                Employee employee = await _employeeRepository.GetEmployeeByName(employeeName);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
        }

        [HttpGet("getby/phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetEmployeeByStatus([FromRoute] string phoneNumber)
        {
                Employee employee = await _employeeRepository.GetEmployeeByPhoneNumber(phoneNumber);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
        }
    }
}
