using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface ICallReportRepository
    {
        Task AddCallReport(CallReport callReport);
        Task UpdateCallReport(CallReport callReport);
        Task<List<CallReport>> GetCallReports();
        Task<CallReport> GetCallReportsByCallReportId(Guid callReportId);
        Task<List<CallReport>> GetCallReportsByWorkId(Guid workId);
    }
}
