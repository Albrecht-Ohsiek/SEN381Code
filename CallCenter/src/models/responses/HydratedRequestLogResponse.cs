using CallCenter.Types;

namespace CallCenter.Models{
    public class HydratedRequestLogResponse{
        public Guid requestId { get; set; }
        public string clientName { get; set; }
        public string clientPhoneNumber {get; set;}
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; }
        public string employeeName { get; set; }
        public Department department {get; set;}
        public string priorityLevel { get; set; }
        public string status { get; set; }
    }
}