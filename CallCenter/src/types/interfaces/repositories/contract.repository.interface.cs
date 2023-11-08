using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IContractRepository
    {
        Task AddContract(Contract contract);
        Task UpdateContract(Contract contract);
        Task<List<Contract>> GetAllContracts();
        Task<Contract> GetContractById(Guid contractId);
        Task<List<Contract>> GetContractByClientId(Guid clientId);
        Task<List<Contract>> GetContractByServiceLevel(string serviceLevel);
        Task<List<Contract>> GetContractByStatus(string contractStatus);

    }
}