using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/contract")]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _contractRepository;

        public ContractController(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContract([FromBody] AddContractRequest contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Contract newContract = new Contract()
            {
                contractId = Guid.NewGuid(),
                clientId = contract.clientId,
                contractType = contract.contractType,
                contractDetails = contract.contractDetails,
                serviceLevel = contract.serviceLevel,
                contractStatus = contract.contractStatus
            };

            await _contractRepository.AddContract(newContract);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateContract([FromBody] UpdateContractRequest contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Contract existingContract = await _contractRepository.GetContractById(contract.contractId);

            Contract newContract = new Contract()
            {
                contractId = existingContract.contractId,
                clientId = existingContract.clientId,
                contractType = contract.contractType ?? existingContract.contractType,
                contractDetails = contract.contractDetails ?? existingContract.contractDetails,
                serviceLevel = contract.serviceLevel ?? existingContract.serviceLevel,
                contractStatus = contract.contractStatus ?? existingContract.contractStatus
            };

            await _contractRepository.UpdateContract(newContract);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetContracts()
        {
            List<Contract> contracts = await _contractRepository.GetAllContracts();
            if (contracts == null)
            {
                return NotFound();
            }
            return Ok(contracts);
        }

        [HttpGet("getby/contractId/{contractId}")]
        public async Task<IActionResult> GetContractByContractId([FromRoute] string reportId)
        {
            if (Guid.TryParse(reportId, out Guid result))
            {
                Contract contract = await _contractRepository.GetContractById(result);
                if (contract == null)
                {
                    return NotFound();
                }
                return Ok(contract);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetContractByClientId([FromRoute] string clientId)
        {
            if (Guid.TryParse(clientId, out Guid result))
            {
                List<Contract> contracts = await _contractRepository.GetContractByClientId(result);
                if (contracts.Count < 1)
                {
                    return NotFound();
                }
                return Ok(contracts);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/serviceLevel/{serviceLevel}")]
        public async Task<IActionResult> GetContractByServiceLevel([FromRoute] int serviceLevel)
        {
            List<Contract> contracts = await _contractRepository.GetContractByServiceLevel(serviceLevel);
            if (contracts != null)
            {
                return NotFound();
            }
            return Ok(contracts);
        }

        [HttpGet("getby/contractStatus/{contractStatus}")]
        public async Task<IActionResult> GetContractByStatus([FromRoute] string contractStatus)
        {
            List<Contract> contracts = await _contractRepository.GetContractByStatus(contractStatus);
            if (contracts.Count < 1)
            {
                return NotFound();
            }
            return Ok(contracts);
        }
    }
}