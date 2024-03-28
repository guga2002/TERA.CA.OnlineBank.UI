using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "POWEREDUSER")]
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
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
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
        [Route("Balance/{Userid}")]
        public async Task<IActionResult> CheckBalance(Guid Userid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var res = await ser.CheckBalance(Userid);
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
        [Route("Profile/{Userid}")]//sxvisi profilis naxva
        [AllowAnonymous]
        public async Task<IActionResult> CheckProfile(Guid Userid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var res = await ser.CheckProfile(Userid);
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
