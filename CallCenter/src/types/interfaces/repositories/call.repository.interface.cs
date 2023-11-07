using CallCenter.Models;

namespace CallCenter.Types
{
    public interface ICallRepository
    {
        Task AddCall(Call call);
        Task UpdateCall(Call call);
        Task<List<Call>> GetAllCalls();
        Task<Call> SelectCallsById(Guid callId);
        Task<List<Call>> SelectCallsByClientId(Guid clientId);
        Task<List<Call>> SelectCallsByWorkId(Guid workId);
    }
}
