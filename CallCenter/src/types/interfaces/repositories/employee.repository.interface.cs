using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IEmployeeRepository{
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(Guid employeeId);
        Task<Employee> GetEmployeeByName(string employeeName);
        Task<Employee> GetEmployeeByPhoneNumber(string phoneNumber);
    }
}