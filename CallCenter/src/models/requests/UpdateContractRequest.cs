using CallCenter.Types;

namespace CallCenter.Models
{
    public class UpdateContractRequest
    {
        public Guid contractId { get; set; }
        public ContractType? contractType { get; set; }
        public string? contractDetails { get; set; }
        public string? serviceLevel { get; set; }
        public ContractStatus? contractStatus { get; set; }
    }
}