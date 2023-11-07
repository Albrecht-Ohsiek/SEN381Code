using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class RequestLogRepository : IRequestLogRepository
    {
        private readonly DatabaseServices _dbService;

        public RequestLogRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<RequestLog>> ExecuteRequestLogQueryAsync(string queryName, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<RequestLog> requestLogs = new List<RequestLog>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            RequestLog requestLog = new RequestLog
                            {
                                requestId = reader.GetGuid(reader.GetOrdinal("requestId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                lastCallDate = reader.GetDateTime(reader.GetOrdinal("lastCallDate")),
                                callDuration = reader.GetDouble(reader.GetOrdinal("callDuration")),
                                technicianId = reader.GetGuid(reader.GetOrdinal("technicianName")),
                                priorityLevel = reader.GetString(reader.GetOrdinal("priorityLevel")),
                                status = reader.GetString(reader.GetOrdinal("status"))

                            };
                            requestLogs.Add(requestLog);
                        }
                    }
                }
                catch (Exception)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw;
                }

                return requestLogs;
            }
        }

        public async Task AddRequestLog(RequestLog requestLog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestLog.requestId),
                new SqlParameter("@clientId", requestLog.clientId),
                new SqlParameter("@lastCallDate", requestLog.lastCallDate),
                new SqlParameter("@callDuration", requestLog.callDuration),
                new SqlParameter("@technicianId", requestLog.technicianId),
                new SqlParameter("@priorityLevel", requestLog.priorityLevel),
                new SqlParameter("@status", requestLog.status),
            };

            await ExecuteRequestLogQueryAsync("createRequestLog", parameters);
        }

        public async Task UpdateRequestLog(RequestLog requestLog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestLog.requestId),
                new SqlParameter("@clientId", requestLog.clientId),
                new SqlParameter("@lastCallDate", requestLog.lastCallDate),
                new SqlParameter("@callDuration", requestLog.callDuration),
                new SqlParameter("@technicianId", requestLog.technicianId),
                new SqlParameter("@priorityLevel", requestLog.priorityLevel),
                new SqlParameter("@status", requestLog.status),
            };

            await ExecuteRequestLogQueryAsync("updateRequestLog", parameters);
        }

        public async Task<List<RequestLog>> GetAllRequestLogs()
        {
            return await ExecuteRequestLogQueryAsync("selectAllRequestLogs");
        }

        public async Task<RequestLog> GetRequestLogById(Guid requestId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@requestId", requestId),
            };

            List<RequestLog> requestLogs = await ExecuteRequestLogQueryAsync("selectRequestLogById", parameters);
            return requestLogs.First();
        }

        public async Task<List<RequestLog>> GetRequestLogByClientId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };

            return await ExecuteRequestLogQueryAsync("selectRequestLogByClientId", parameters);        
        }

        public async Task<List<RequestLog>> GetRequestLogByTechnicianId(Guid technicianId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@technicianId", technicianId),
            };

            return await ExecuteRequestLogQueryAsync("selectRequestLogByTechnicianName", parameters);
        }

        public async Task<List<RequestLog>> GetRequestLogtByPriority(string priorityLevel)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@status", priorityLevel),
            };

            return await ExecuteRequestLogQueryAsync("selecRequestLogByPriority", parameters);
        }

        public async Task<List<RequestLog>> GetRequestLogtByStatus(string status)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@status", status),
            };

            return await ExecuteRequestLogQueryAsync("selecRequestLogByStatus", parameters);
        }

    }
}