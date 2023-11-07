namespace CallCenter.Types
{
    interface IWork{
        Guid workId {get; set;}
        Guid technicianId {get; set;}
        DateTime workDate {get; set;}

    }
}