using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IRequestLogRepository
    {
        Task AddRequestLog(RequestLog requestLog);
        Task UpdateRequestLog(RequestLog requestLog);
        Task<List<RequestLog>> GetAllRequestLogs(); 
        Task<RequestLog> GetRequestLogById(Guid requestId);
        Task<List<RequestLog>> GetRequestLogByClientId(Guid clientId);
        Task<List<RequestLog>> GetRequestLogByTechnicianId(Guid technicianId);
        Task<List<RequestLog>> GetRequestLogtByPriority(string priorityLevel);
        Task<List<RequestLog>> GetRequestLogtByStatus(string status);
    }
}