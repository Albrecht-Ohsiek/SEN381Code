
namespace CallCenter.Types
{
    interface IEmployee
    {
        Guid employeeId { get; set; }
        string employeeName { get; set; }
        Department department { get; set; }
        string emailAddress { get; set; }
        string phoneNumber { get; set; }
    }
}