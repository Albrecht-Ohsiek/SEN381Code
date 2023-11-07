using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class CallRepository : ICallRepository
    {
        private readonly DatabaseServices _dbService;

        public CallRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Call>> ExecuteCallQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Call> calls = new List<Call>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Call call = new Call
                            {
                                callId = reader.GetGuid(reader.GetOrdinal("callId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                startTime = reader.GetDateTime(reader.GetOrdinal("startTime")),
                                endTime = reader.IsDBNull(reader.GetOrdinal("endTime")) ? null : reader.GetDateTime(reader.GetOrdinal("endTime")),
                                employeeId = reader.GetGuid(reader.GetOrdinal("employeeId")),
                                workId = reader.IsDBNull(reader.GetOrdinal("workId")) ? null : reader.GetGuid(reader.GetOrdinal("workId"))
                            };
                            calls.Add(call);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return calls;
            }
        }
        
        public async Task AddCall(Call call)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callId", call.callId),
                new SqlParameter("@clientId", call.clientId),
                new SqlParameter("@startTime", call.startTime),
                new SqlParameter("@workId", call.workId),
                new SqlParameter("@startTime", call.startTime),
                new SqlParameter("@endTime", call.endTime)
            };

            await ExecuteCallQueryAsync("createNewCall", parameters);
        }

        public async Task UpdateCall(Call call)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callId", call.callId),
                new SqlParameter("@clientId", call.clientId),
                new SqlParameter("@employeeId", call.employeeId),
                new SqlParameter("@workId", call.workId),
                new SqlParameter("@startTime", call.startTime),
                new SqlParameter("@endTime", call.endTime)
            };

            await ExecuteCallQueryAsync("updateCallsById", parameters);
        }

        public async Task<List<Call>> GetAllCalls()
        {
            return await ExecuteCallQueryAsync("selectAllCalls");
        }

        public async Task<Call> SelectCallsById(Guid callId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callId", callId)
            };

            List<Call> calls = await ExecuteCallQueryAsync("selectCallsById", parameters);

            return calls.First();
        }

        public async Task<List<Call>> SelectCallsByClientId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId)
            };

            return await ExecuteCallQueryAsync("selectCallsByClientId", parameters);
        }

        public async Task<List<Call>> SelectCallsByWorkId(Guid workId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@workId", workId)
            };

            return await ExecuteCallQueryAsync("selectCallsByWorkId", parameters);
        }
    }
}
