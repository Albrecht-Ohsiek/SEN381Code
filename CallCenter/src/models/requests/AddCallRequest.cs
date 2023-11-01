namespace CallCenter.Models{
    public class AddCallToRequest{
        public Guid ClientId { get ; set ; }
        public DateTime StartTime { get ; set ; }
        public DateTime? EndTime {get; set;}
        public Guid EmployeeId { get ; set ; }
        public Guid? WorkId {get; set;}
    }
}