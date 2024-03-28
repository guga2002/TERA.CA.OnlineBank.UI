using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "POWEREDUSER,ADMIN")]
    public class OnlineBankController : ControllerBase
    {
        private readonly IOnlineBankServices ser;
        private readonly ILogger<OnlineBankController> logger;  
        public OnlineBankController(IOnlineBankServices ser, ILogger<OnlineBankController> logger)
        {
            this.ser = ser;
            this.logger = logger;

        }
        [HttpPost]
        [Route("Transfer")]
        public async Task<IActionResult> TransferMoney(TransactionModel mod)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid || userId == null)
                {
                    return BadRequest();
                }
                mod.SenderId = Guid.Parse(userId);
                var res = await ser.TransferMoney(mod);
                if(!res)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Balance")]
        public async Task<IActionResult> CheckBalance()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid||userId==null)
                {
                    return BadRequest();
                }
                var res = await ser.CheckBalance(Guid.Parse(userId));
                if(res==null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> CheckProfile()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!ModelState.IsValid||userId==null)
                {
                    return BadRequest();
                }
               
                var res = await ser.CheckProfile(Guid.Parse(userId));
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }
    }
}
