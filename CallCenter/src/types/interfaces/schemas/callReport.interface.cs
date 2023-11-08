using CallCenter.Models;

namespace CallCenter.Types{
    interface ICallReport
    {   
        Guid callReportId{get; set;}
        Guid workId {get; set;}
        List<Id>? calls {get; set;}
    }
}