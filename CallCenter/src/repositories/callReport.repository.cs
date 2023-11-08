using System.Data;
using CallCenter.Models;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class CallReportRepository : ICallReportRepository
    {
        private readonly DatabaseServices _dbService;

        public CallReportRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<CallReport>> ExecuteCallReportQueryAsync(string queryName, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<CallReport> calls = new List<CallReport>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            CallReport callReport = new CallReport
                            {
                                callReportId = reader.GetGuid(reader.GetOrdinal("callReportId")),
                                workId = reader.GetGuid(reader.GetOrdinal("workId")),
                            };
                            string callsString = reader.GetString(reader.GetOrdinal("calls"));
                            callReport.calls = callsString.Split(',').Select(s => new Id { id = Guid.Parse(s) }).ToList();

                            calls.Add(callReport);
                        }
                    }
                }
                catch
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw;
                }

                return calls;
            }
        }
        public async Task AddCallReport(CallReport callReport)
        {
            string callsString = string.Join(",", callReport.calls.Select(id => id.id));

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callReportId", callReport.callReportId),
                new SqlParameter("@workId", callReport.workId),
                new SqlParameter("@calls", callsString)
            };

            await ExecuteCallReportQueryAsync("createNewCallReport", parameters);
        }

        public async Task UpdateCallReport(CallReport callReport)
        {
            string callsString = string.Join(",", callReport.calls.Select(id => id.id));

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callReportId", callReport.callReportId),
                new SqlParameter("@calls", callsString),
            };

            await ExecuteCallReportQueryAsync("updateCallReport", parameters);
        }

        public async Task<List<CallReport>> GetCallReports()
        {
            return await ExecuteCallReportQueryAsync("getAllCallReports");
        }

        public async Task<CallReport> GetCallReportsByCallReportId(Guid callReportId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@callReportId", callReportId)
            };

            List<CallReport> callReports = await ExecuteCallReportQueryAsync("getAllCallReportsById", parameters);
            return callReports.FirstOrDefault();
        }

        public async Task<List<CallReport>> GetCallReportsByWorkId(Guid workId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@workId", workId)
            };

            return await ExecuteCallReportQueryAsync("getAllCallReportsByWorkId", parameters);
        }
    }
}
