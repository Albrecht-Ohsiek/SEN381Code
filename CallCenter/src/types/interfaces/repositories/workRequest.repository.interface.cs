using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IWorkRequestRepository
    {
        Task AddWorkRequest(WorkRequest workRequest);
        Task UpdateWorkRequest(WorkRequest workRequest);
        Task<List<WorkRequest>> GetAllWorkRequests();
        Task<WorkRequest> GetWorkRequestById(Guid requestId);
        Task<List<WorkRequest>> GetWorkRequestByClientId(Guid clientId);
        Task<List<WorkRequest>> GetWorkRequestByPriority(string priority);
        Task<List<WorkRequest>> GetWorkRequestByServiceType(string serviceType);
        Task<List<WorkRequest>> GetWorkRequestByStatus(string status);
    }
}