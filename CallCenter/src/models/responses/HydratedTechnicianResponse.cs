namespace CallCenter.Models
{
    public class HydratedTechnicianResponse
    {
        public Guid technicianId {get; set;}
        public required string employeeName {get; set;}
        public required string phoneNumber {get; set;}
        public required string email{get; set;}
        public int skillLevel {get; set;}
        public bool availability { get; set; }
        public required string serviceArea { get; set; }
        public required string certificationLevel { get; set; }
    }
}