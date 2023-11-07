namespace CallCenter.Models
{
    public class UpdateCallReportRequest
    {
        public Guid callReportId {get; set;}
        public required List<Call> calls { get; set; }
    }
}