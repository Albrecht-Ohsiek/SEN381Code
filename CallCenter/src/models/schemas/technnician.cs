using CallCenter.Types;

namespace CallCenter.Models
{
    public class Technician : ITechnician
    {
        public Guid technicianId {get; set;}
        public Guid employeeId {get; set;}
        public int skillLevel {get; set;}
        public bool availability { get; set; }
        public required string serviceArea { get; set; }
        public required string certificationLevel { get; set; }
    
        public Technician()
        {

        }
        
        public Technician(Guid technicianId, Guid employeeId, int skillLevel, bool availability, string serviceArea, string certificationLevel)
        {
            this.technicianId = technicianId;
            this.skillLevel = skillLevel;
            this.employeeId = employeeId;
            this.availability = availability;
            this.serviceArea = serviceArea;
            this.certificationLevel = certificationLevel;
        }
    }
}