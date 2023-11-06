using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class EmployeeLoginRepository
    {
        private readonly DatabaseServices _dbService;

        public EmployeeLoginRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Login>> ExecuteEmployeeLoginQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Login> logins = new List<Login>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Login login = new Login
                            {
                                EmployeeId = reader.GetGuid(reader.GetOrdinal("employeeId")),
                                Username = reader.GetString(reader.GetOrdinal("employeeName")),
                                Password = reader.GetString(reader.GetOrdinal("employeeName"))

                            };

                            logins.Add(login);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return logins;
            }
        }

        public async Task AddEmployeeLogin(AddLoginRequest login)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", login.username),
                new SqlParameter("@password", login.password),
            };

            await ExecuteEmployeeLoginQueryAsync("createEmployeeLogin", parameters);
        }

        public async Task UpdateEmployeeLogin(Login login)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@employeeId", login.EmployeeId),
                new SqlParameter("@username", login.Username),
                new SqlParameter("@password", login.Password),
            };

            await ExecuteEmployeeLoginQueryAsync("updateEmployeeLogin", parameters);
        }

        public async Task<Login> GetEmployeeLoginByName(string username)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
            };

            List<Login> employeeLogins = await ExecuteEmployeeLoginQueryAsync("selectEmployeLoginByName", parameters);
            return employeeLogins.First();
        }
    }
}