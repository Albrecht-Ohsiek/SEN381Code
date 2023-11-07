using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IEmployeeLoginRepository
    {
        Task AddEmployeeLogin(AddLoginRequest login);
        Task UpdateEmployeeLogin(Login login);
        Task<Login> GetEmployeeLoginByName(string username);
    }
}