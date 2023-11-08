using CallCenter.Types;

namespace CallCenter.Models
{
    public class AddEmployeeRequest
    {
        public required string employeeName { get; set; }
        public Department department { get; set; }
        public required string emailAddress { get; set; }
        public required string phoneNumber { get; set; }
    }
}