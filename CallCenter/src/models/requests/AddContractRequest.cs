using CallCenter.Types;

namespace CallCenter.Models
{
    public class AddContractRequest
    {
        public Guid clientId { get; set; }
        public ContractType contractType { get; set; }
        public required string contractDetails { get; set; }
        public int serviceLevel { get; set; }
        public ContractStatus contractStatus { get; set; }
    }
}