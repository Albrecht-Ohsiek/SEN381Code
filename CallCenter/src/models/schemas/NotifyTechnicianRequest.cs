namespace CallCenter.Models
{
    public class NotifyTechnicianRequest
    {
        //technician details for express work request form
        public required string ClientName { get; set; }
        public required string ClientPhone { get; set; }
        public required string ClientAddress { get; set; }
        public required string ProblemDescription { get; set; }
        public required string TechnicianId { get; set; }
        public bool NotifyEmail { get; set; }
        public bool NotifySMS { get; set; }
        public bool NotifyWhatsapp { get; set; }
    }
}
