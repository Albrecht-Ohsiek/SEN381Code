using CallCenter.Types;

namespace CallCenter.Models
{
    public class Contract : IContract
    {
        public Guid contractId { get ; set ; }
        public Guid clientId { get ; set ; }
        public ContractType contractType { get ; set ; }
        public required string contractDetails { get ; set ; }
        public int serviceLevel { get ; set ; }
        public ContractStatus contractStatus { get ; set ; }
    
        public Contract()
        {
            
        }

        public Contract(Guid contractId, Guid clientId, ContractType contractType, string contractDetails, int serviceLevel, ContractStatus contractStatus)
        {
            this.contractId = contractId;
            this.clientId = clientId;
            this.contractType = contractType;
            this.contractDetails = contractDetails;
            this.serviceLevel = serviceLevel;
            this.contractStatus = contractStatus;
        }
    }
}