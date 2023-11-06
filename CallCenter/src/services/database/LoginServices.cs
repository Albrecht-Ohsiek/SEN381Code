using CallCenter.DataAccess;
using CallCenter.Models;
using CallCenter.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CallCenter.Services
{
    public class LoginServices
    {
        private readonly EmployeeLoginRepository _employeeLoginRepository;

        public LoginServices(EmployeeLoginRepository employeeLoginRepository)
        {
            _employeeLoginRepository = employeeLoginRepository;
        }

        public async Task<string> AuthenticateUser(AddLoginRequest user)
        {
            Login exsistingUser = await _employeeLoginRepository.GetEmployeeLoginByName(user.username);

            if (exsistingUser == null)
            {
                return "Invalid Username";
            }

            if (user.username == exsistingUser.Username && user.password == exsistingUser.Password)
            {
                return "Login Successful";
            }
            else if(user.password == exsistingUser.Password)
            {
                return "Invalid Password";
            }
            return "Unexpected Error";
        }
    }
}
