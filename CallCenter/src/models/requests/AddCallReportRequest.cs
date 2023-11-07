namespace CallCenter.Models
{
    public class AddCallReportRequest
    {
        public Guid workId { get; set; }
        public required List<Call> calls { get; set; }
    }
}