namespace CallCenter.Types
{
    interface ICall{
        Guid callId {get; set;}
        Guid clientId {get; set;}
        DateTime startTime {get; set;}
        DateTime? endTime {get; set;}
        Guid employeeId {get; set;}
        Guid? workId {get; set;}
    }
}