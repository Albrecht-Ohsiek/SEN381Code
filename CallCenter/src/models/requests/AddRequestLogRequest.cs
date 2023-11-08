namespace CallCenter.Models
{
    public class AddRequestLogRequest
    {
        public Guid clientId { get; set; }
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; }
        public Guid technicianId { get; set; }
        public string priorityLevel { get; set; }
        public string status { get; set; }
    }
}