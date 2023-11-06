using System.ComponentModel.DataAnnotations;

namespace CallCenter.Types{
    public enum ContractStatus{
        [Display(Name = "Basic Maintenance Plan")]
        BasicMaintanacePlan,
        [Display(Name = "Premium Support Plan")]
        PremiumSupportPlan,

        [Display(Name = "Comprehensive Coverage Plan")]
        ComprehensiveCoveragePlan,

        [Display(Name = "Seasonal Tune-Up Plan")]
        SeasonalTuneUpPlan,

        [Display(Name = "Customizable Service Plan")]
        Undefined
    }
}
