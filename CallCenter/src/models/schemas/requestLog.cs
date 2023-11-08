using CallCenter.Types;

namespace CallCenter.Models
{
    public class RequestLog : IRequestLog
    {
        public Guid requestId { get; set; }
        public Guid clientId { get; set; }
        public DateTime lastCallDate { get; set; }
        public double callDuration { get; set; } //in minutes
        public Guid technicianId { get; set; }
        public required string priorityLevel { get; set; }
        public required string status { get; set; }

        public RequestLog()
        {

        }

        public RequestLog(Guid clientId, DateTime lastCallDate, int callDuration, Guid requestId, Guid technicianId, string priorityLevel, string status)
        {
            this.clientId = clientId;
            this.lastCallDate = lastCallDate;
            this.callDuration = callDuration;
            this.requestId = requestId;
            this.technicianId = technicianId;
            this.priorityLevel = priorityLevel;
            this.status = status;
        }
    }
}
