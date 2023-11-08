namespace CallCenter.Models
{
    public class AddCallReportRequest
    {
        public Guid workId { get; set; }
        public List<Id>? calls { get; set; }
    }
}