using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineBankController : ControllerBase
    {
        [HttpPost]
        [Route("Transfer")]
        public async Task<IActionResult> TransferMoney(TransactionModel mod)
        {
            return Ok();
        }
        [HttpGet]
        [Route("Balance/{Userid}")]
        public async Task<IActionResult> CheckBalance(Guid Userid)
        {
            return Ok();
        }
        [HttpGet]
        [Route("Profile/{Userid}")]
        public async Task<IActionResult> CheckProfile(Guid Userid)
        {
            return Ok();
        }
    }
}
