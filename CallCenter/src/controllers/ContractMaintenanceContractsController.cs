using CallCenter.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/ContractMaintenanceContracts")]
    public class ContractMaintenanceContractsController
    {
        [HttpPost("DefineService")]
        public IActionResult DefineService()
        {
            return ContractMaintananceHandler.DefineService();
        }

        [HttpPost("DefineServiceLevels")]
        public IActionResult DefineServiceLevels()
        {
            return ContractMaintananceHandler.DefineServiceLevels();
        }

        [HttpPost("DefineContractType")]
        public IActionResult DefineContractType()
        {
            return ContractMaintananceHandler.DefineContractType();
        }

        [HttpGet("GetContractAvailable")]
        public IActionResult GetContractAvailable()
        {
            return ContractMaintananceHandler.GetContractAvailable();
        }

        [HttpGet("ViewPerformance")]
        public IActionResult AddCallToRequest()
        {
            return ContractMaintananceHandler.AddCallToRequest();
        }
    }
}