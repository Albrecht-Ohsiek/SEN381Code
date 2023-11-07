using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IWorkRepository
    {
        Task AddWork(Work work);
        Task UpdateWork(Work work);
        Task<List<Work>> GetAllWorks();
        Task<Work> GetWorkById(Guid workId);
        Task<List<Work>> GetWorkByTechnicianId(Guid technicianId);
    }
}