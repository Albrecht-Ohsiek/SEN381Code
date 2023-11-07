using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(Guid clientId);
        Task<List<Client>> GetClientByName(string clientName);
        Task<Client> GetClientByPhoneNumber(string phoneNumber);
    }
}