using CallCenter.Models;

namespace CallCenter.Types{
    interface ICallReport
    {   
        Guid callReportId{get; set;}
        Guid workId {get; set;}
        List<Call> calls {get; set;}
    }
}