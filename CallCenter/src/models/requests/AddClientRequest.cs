using CallCenter.Types;

namespace CallCenter.Models{
    public class AddClientRequest{
        public required string clientName { get ; set ; }
        public required string phoneNumber { get ; set ; }
        public ClientTypes clientType { get ; set ; }
        public List<Contract>? contracts { get ; set ; }
        public required string clientAddress { get; set; }
        public DateTime? lastCallDate { get; set; }
        public string? clientNotes { get; set; }
    }
}