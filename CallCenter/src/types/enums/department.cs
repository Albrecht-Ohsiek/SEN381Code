using System.ComponentModel.DataAnnotations;

namespace CallCenter.Types
{
    public enum Department
    {
        [Display(Name = "Administration")]
        Administration,

        [Display(Name = "Customer Service")]
        CustomerService,

        [Display(Name = "Technical Support")]
        TechnicalSupport,

        [Display(Name = "Undefined")]
        Undefined
    }
}