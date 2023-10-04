using CallCenter.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/ClientMaintanance")]
    public class ClientMaintanaceController
    {
        [HttpPost("AddClient")]
        public IActionResult AddClient()
        {
            return ClientMaintananceHandler.AddClient();
        }

        [HttpPost("AddBusinessClient")]
        public IActionResult AddBusinessClient()
        {
            return ClientMaintananceHandler.AddBusinessClient();
        }

        [HttpPost("AddServiceAgreement")]
        public IActionResult AddServiceAgreement()
        {
            return ClientMaintananceHandler.AddServiceAgreement();
        }

        [HttpGet("ViewContractHistory")]
        public IActionResult ViewContractHistory()
        {
            return ClientMaintananceHandler.ViewContractHistory();
        }
    }
}