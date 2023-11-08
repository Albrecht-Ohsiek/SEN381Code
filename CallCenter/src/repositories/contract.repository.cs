using System.Data;
using CallCenter.Models;
using CallCenter.Types;
using Microsoft.Data.SqlClient;

namespace CallCenter.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly DatabaseServices _dbService;

        public ContractRepository(DatabaseServices dbService)
        {
            _dbService = dbService;
        }

        private async Task<List<Contract>> ExecuteContractQueryAsync(string queryName, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = _dbService.GetOpenConnection())
            using (SqlCommand command = _dbService.CreateCommand(queryName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                List<Contract> contracts = new List<Contract>();

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Contract contract = new Contract
                            {
                                contractId = reader.GetGuid(reader.GetOrdinal("contractId")),
                                clientId = reader.GetGuid(reader.GetOrdinal("clientId")),
                                contractDetails = reader.GetString(reader.GetOrdinal("contractDetails")),
                                serviceLevel = reader.GetString(reader.GetOrdinal("serviceLevel")),
                            };
                            string contractTypeValue = reader.GetString(reader.GetOrdinal("contractType"));
                            if (Enum.TryParse<ContractType>(contractTypeValue, out ContractType contractType))
                            {
                                contract.contractType = contractType;
                            }
                            else
                            {
                                contract.contractType  = ContractType.Undefined;
                            }
                            string contractStatusValue = reader.GetString(reader.GetOrdinal("contractStatus"));
                            if (Enum.TryParse<ContractStatus>(contractTypeValue, out ContractStatus contractStatus))
                            {
                                contract.contractStatus = contractStatus;
                            }
                            else
                            {
                                contract.contractStatus  = ContractStatus.Undefined;
                            }

                            contracts.Add(contract);
                        }
                    }
                }
                catch (Exception)
                {
                    // Handle any exceptions that may occur during the execution of the stored procedure.
                    throw;
                }

                return contracts;
            }
        }

        public async Task AddContract(Contract contract)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractID", contract.contractId),
                new SqlParameter("@clientId", contract.clientId),
                new SqlParameter("@contractType", contract.contractType),
                new SqlParameter("@contractDetails", contract.contractDetails),
                new SqlParameter("@serviceLevel", contract.serviceLevel),
                new SqlParameter("@contractStatus", contract.contractStatus),
            };

            await ExecuteContractQueryAsync("createContract", parameters);
        }

        public async Task UpdateContract(Contract contract)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractID", contract.contractId),
                new SqlParameter("@clientId", contract.clientId),
                new SqlParameter("@contractType", contract.contractType),
                new SqlParameter("@contractDetails", contract.contractDetails),
                new SqlParameter("@serviceLevel", contract.serviceLevel),
                new SqlParameter("@contractStatus", contract.contractStatus),
            };

            await ExecuteContractQueryAsync("updateContract", parameters);
        }
        public async Task<List<Contract>> GetAllContracts()
        {
            return await ExecuteContractQueryAsync("selectAllContracts");
        }

        public async Task<Contract> GetContractById(Guid contractId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractId", contractId),
            };

            List<Contract> contracts = await ExecuteContractQueryAsync("selectContractById", parameters);
            return contracts.FirstOrDefault();
        }

        public async Task<List<Contract>> GetContractByClientId(Guid clientId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@clientId", clientId),
            };
            return await ExecuteContractQueryAsync("selectContractByClientId", parameters);
        }

        public async Task<List<Contract>> GetContractByServiceLevel(string serviceLevel)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@serviceLevel", serviceLevel),
            };

            return await ExecuteContractQueryAsync("selectContractByServiceLevel", parameters);
        }

        public async Task<List<Contract>> GetContractByStatus(string contractStatus)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contractStatus", contractStatus),
            };

            return await ExecuteContractQueryAsync("selectContractByContractStatus", parameters);
        }

    }
}