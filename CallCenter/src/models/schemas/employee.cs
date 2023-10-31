using CallCenter.Types;

namespace CallCenter.Models
{
    public class Employee : IEmployee
    {
        public Guid employeeId { get; set; }
        public string employeeName { get; set; }
        public Department department { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }

        public Employee()
        {

        }
        public Employee(Guid employeeID, string employeeName, Department department, string emailAddress, string phoneNumber)
        {
            this.employeeId = employeeID;
            this.employeeName = employeeName;
            this.department = department;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
        }
    }
}