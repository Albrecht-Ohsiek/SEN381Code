using CallCenter.Types;

namespace CallCenter.Models{
    public class CallReport : ICallReport
    {
        public Guid callReportId {get; set;}     
        public Guid workId { get ; set ; }
        public List<Id>? calls { get ; set ; }
    
        public CallReport()
        {
        }

        public CallReport(Guid callReportId, Guid workId, List<Id> calls)
        {
            this.callReportId = callReportId;
            this.workId = workId;
            this.calls = calls;
        }
        
    }
}