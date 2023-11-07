using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseServices _dbService;

        public ClientRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Client>> ExecuteClientQueryAsync(string queryName, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Client> clients = new List<Client>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Client client = new Client
                            {
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                clientName = reader.GetString(reader.GetOrdinal("clientName")),
                                phoneNumber = reader.GetString(reader.GetOrdinal("phoneNumber")),
                                clientAddress = reader.GetString(reader.GetOrdinal("address")),
                                lastCallDate = reader.GetDateTime(reader.GetOrdinal("lastCallDate")),
                                clientNotes = reader.GetString(reader.GetOrdinal("clientNotes"))
                            };
                            string clientTypeValue = reader.GetString(reader.GetOrdinal("clientType"));
                            if (Enum.TryParse<ClientTypes>(clientTypeValue, out ClientTypes clientTypes))
                            {
                                client.clientType = clientTypes;
                            }
                            else
                            {
                                client.clientType = ClientTypes.Undefined;
                            }
                            clients.Add(client);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw ex;
                }

                return clients;
            }
        }

        public async Task AddClient(Client client)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", client.clientId),
                new SqlParameter("@clientName", client.clientName),
                new SqlParameter("@phoneNumber", client.phoneNumber),
                new SqlParameter("@clientType", client.clientType),
                new SqlParameter("@address", client.clientAddress),
                new SqlParameter("@lastCallDate", client.lastCallDate),
                new SqlParameter("@clientNotes", client.clientNotes),
            };

            await ExecuteClientQueryAsync("createClient", parameters);
        }

        public async Task UpdateClient(Client client)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", client.clientId),
                new SqlParameter("@clientName", client.clientName),
                new SqlParameter("@phoneNumber", client.phoneNumber),
                new SqlParameter("@clientType", client.clientType),
                new SqlParameter("@address", client.clientAddress),
                new SqlParameter("@lastCallDate", client.lastCallDate),
                new SqlParameter("@clientNotes", client.clientNotes),
            };

            await ExecuteClientQueryAsync("updateClient", parameters);
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await ExecuteClientQueryAsync("selectAllClients");
        }

        public async Task<Client> GetClientById(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };

            List<Client> clients = await ExecuteClientQueryAsync("selectClientById", parameters);
            return clients.First();
        }

        public async Task<List<Client>> GetClientByName(string clientName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientName", clientName),
            };

            return await ExecuteClientQueryAsync("selectClientByName", parameters);
        }

        public async Task<Client> GetClientByPhoneNumber(string phoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@phoneNumber", phoneNumber),
            };

            List<Client> clients = await ExecuteClientQueryAsync("selectClientByPhone", parameters);
            return clients.First();
        }

    }
}