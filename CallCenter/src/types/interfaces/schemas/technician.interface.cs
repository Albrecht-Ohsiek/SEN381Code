namespace CallCenter.Types
{
    interface ITechnician
    {
        Guid technicianId {get; set;}
        Guid employeeId {get; set;}
        int skillLevel {get; set;}
        bool availability { get; set; }
        string serviceArea { get; set; }
        string certificationLevel { get; set; }
    }
}