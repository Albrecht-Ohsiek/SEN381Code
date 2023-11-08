namespace CallCenter.Models
{
    public class AddTechnicianRequest
    {
        public Guid employeeId {get; set;}
        public int skillLevel {get; set;}
        public bool availability { get; set; }
        public required string serviceArea { get; set; }
        public required string certificationLevel { get; set; }
    }
}