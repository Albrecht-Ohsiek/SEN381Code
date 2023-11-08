using CallCenter.Controllers;
using CallCenter.Repository;
using CallCenter.Types;
using CallCenter.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminController : Controller
    {
        private readonly IRequestLogRepository _requestLogRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IClientRepository _clientRepository;

        public AdminController(IRequestLogRepository requestLogRepository, ITechnicianRepository technicianRepository, IEmployeeRepository employeeRepository, IClientRepository clientRepository)
        {
            _requestLogRepository = requestLogRepository;
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        
        public async Task<IActionResult> AdminEmployees()
        {
            return View(await _employeeRepository.GetAllEmployees());
        }

        public async Task<IActionResult> AdminRequestLogs()
        {    
            return View(await _requestLogRepository.GetAllRequestLogs());
        }

        // GET: Employee/Details/?
        public async Task<IActionResult> EmployeeDetails(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public async Task<IActionResult> EmployeeEdit(UpdateEmployeeRequest emp)
        {
            if (emp == null)
            {
                return NotFound();
            }

            // Assume emp.department is of type Department?
            CallCenter.Types.Department nonNullableDepartment;

            // Check if emp.department has a value, and if not, assign a default value
            if (emp.department.HasValue)
            {
                // Use the Value property to access the non-nullable value
                nonNullableDepartment = emp.department.Value;
            }
            else
            {
                // Assign a default value (you can use a different default value)
                nonNullableDepartment = CallCenter.Types.Department.Undefined;
            }

            // Create an Employee object and set its properties
            Employee employee = new Employee
            {
                // Assign other properties
                employeeId = emp.employeeId,
                employeeName = emp.employeeName,
                // Assign the non-nullable department
                department = nonNullableDepartment,
                emailAddress = emp.emailAddress,
                phoneNumber = emp.phoneNumber
            };

            // Update the employee
            await _employeeRepository.UpdateEmployee(employee);

            // Redirect to the EmployeeDetails page
            return RedirectToAction("EmployeeDetails", new { id = emp.employeeId });
        }

    }
}
