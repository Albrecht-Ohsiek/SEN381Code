using CallCenter.Models;
using CallCenter.Repository;

namespace CallCenter.Services
{
    public class LoginServices
    {
        private readonly IEmployeeLoginRepository _employeeLoginRepository;

        public LoginServices(IEmployeeLoginRepository employeeLoginRepository)
        {
            _employeeLoginRepository = employeeLoginRepository;
        }

        public LoginServices()
        {
            
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
