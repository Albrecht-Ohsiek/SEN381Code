namespace CallCenter.Models
{
    public class AddRequestLogRequest
    {
        public Guid clientId { get; set; }
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; }
        public Guid technicianId { get; set; }
        public required string priorityLevel { get; set; }
        public required string status { get; set; }
    }
}