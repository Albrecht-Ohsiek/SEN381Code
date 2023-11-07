namespace CallCenter.Types
{
    public interface IRequestLog
    {
        Guid requestId { get; set; }
        Guid clientId { get; set; }
        DateTime lastCallDate { get; set; }
        double callDuration { get; set; }
        Guid technicianId { get; set; }
        string priorityLevel { get; set; }
        string status { get; set; }

    }
}
