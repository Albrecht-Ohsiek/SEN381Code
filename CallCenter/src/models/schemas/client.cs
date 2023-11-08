using CallCenter.Types;

namespace CallCenter.Models
{
    public class Client : IClient
    {
        public Guid clientId { get ; set ; }
        public required string clientName { get ; set ; }
        public required string phoneNumber { get ; set ; }
        public ClientTypes clientType { get ; set ; }
        public List<Contract>? contracts { get ; set ; }
        public required string clientAddress { get; set; }
        public DateTime? lastCallDate { get; set; }
        public string? clientNotes { get; set; }

        public Client()
        {
        }

        public Client(Guid clientId, string clientName, string phoneNumber, ClientTypes clientType, List<Contract> contracts, string clientAddress, DateTime lastCallDate, Guid requestId, Guid employeeId, string clientNotes)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.clientType = clientType;
            this.contracts = contracts;
            this.clientAddress = clientAddress;
            this.lastCallDate = lastCallDate;
            this.clientNotes = clientNotes;
        }
    }
}