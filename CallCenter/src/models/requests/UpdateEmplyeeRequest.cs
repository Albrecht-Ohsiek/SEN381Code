using System;
using CallCenter.Types;

namespace CallCenter.Models
{
    public class UpdateEmployeeRequest
    {
        public Guid employeeId{get; set;}
        public string? employeeName { get; set; }
        public Department? department { get; set; }
        public string? emailAddress { get; set; }
        public string? phoneNumber { get; set; }
    }
}