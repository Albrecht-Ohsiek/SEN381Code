namespace CallCenter.Models
{
    public class AddWorkRequestRequest
    {
        public Guid clientId { get; set; }
        public required string serviceType { get; set; }
        public required string priority { get; set; }
        public required string status { get; set; }
    }
}