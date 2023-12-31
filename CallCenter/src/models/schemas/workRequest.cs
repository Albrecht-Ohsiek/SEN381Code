using CallCenter.Types;

namespace CallCenter.Models
{
    public class WorkRequest : IWorkRequest
    {
        public Guid requestId { get; set; }
        public Guid clientId { get; set; }
        public string serviceType { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        
        public WorkRequest()
        {

        }

        public WorkRequest(Guid requestId, Guid clientId, string serviceType, string priority, string status)
        {
            this.requestId = requestId;
            this.clientId = clientId;
            this.serviceType = serviceType;
            this.priority = priority;
            this.status = status;
        }
    }
}