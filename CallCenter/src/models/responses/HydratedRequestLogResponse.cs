using CallCenter.Types;

namespace CallCenter.Models.Responses{
    public class HydratedRequestLogResponse{
        public Guid requestId { get; set; }
        public required string clientName { get; set; }
        public required string clientPhoneNumber {get; set;}
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; }
        public required string employeeName { get; set; }
        public Department department {get; set;}
        public required string priorityLevel { get; set; }
        public required string status { get; set; }
    }
}