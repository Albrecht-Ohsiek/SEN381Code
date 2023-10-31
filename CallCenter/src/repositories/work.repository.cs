using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class WorkRepository
    {
        private readonly DatabaseServices _dbService;

        public WorkRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Work>> ExecuteWorkQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Work> works = new List<Work>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Work work = new Work
                            {
                                workId = reader.GetGuid(reader.GetOrdinal("worId")),
                                technicianId = reader.GetGuid(reader.GetOrdinal("technicianId")),
                                workDate = reader.GetDateTime(reader.GetOrdinal("workDate")),
                            };
                            works.Add(work);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return works;
            }
        }

        public async Task AddCall(Work work)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@workId", work.workId),
                new SqlParameter("@technicianId", work.technicianId),
                new SqlParameter("@workDate", work.workDate),
            };

            await ExecuteWorkQueryAsync("createWork", parameters);
        }

        public async Task UpdateWork(Work work)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@workId", work.workId),
                new SqlParameter("@technicianId", work.technicianId),
                new SqlParameter("@workDate", work.workDate),
            };

            await ExecuteWorkQueryAsync("updateWork", parameters);
        }

        public async Task<List<Work>> GetAllWorks()
        {
            return await ExecuteWorkQueryAsync("selectAllWorks");
        }

        public async Task GetWorkById(Guid workId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@workId", workId),
            };

            await ExecuteWorkQueryAsync("selectWorkById", parameters);
        }

        public async Task GetWorkByTechnicianId(Guid technicianId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianId", technicianId),
            };

            await ExecuteWorkQueryAsync("selectWorkById", parameters);
        }

    }
}