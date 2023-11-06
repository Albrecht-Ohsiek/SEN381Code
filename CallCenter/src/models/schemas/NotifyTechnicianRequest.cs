namespace CallCenter.Models
{
    public class NotifyTechnicianRequest
    {
        //technician details for express work request form
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public string ProblemDescription { get; set; }
        public string TechnicianId { get; set; }
        public bool NotifyEmail { get; set; }
        public bool NotifySMS { get; set; }
        public bool NotifyWhatsapp { get; set; }
    }
}
