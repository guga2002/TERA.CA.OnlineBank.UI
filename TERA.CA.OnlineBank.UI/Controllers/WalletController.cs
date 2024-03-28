using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "POWEREDUSER,ADMIN")]
    public class WalletController : ControllerBase
    {

        private readonly IWalletServices ser;
        private readonly ILogger<WalletController> log;

        public WalletController(IWalletServices ser, ILogger<WalletController> log)
        {
            this.ser = ser;
            this.log = log;

        }
        [HttpPost]
        public async Task<IActionResult> Create(WalletModel entity)
        {
            try
            {
                if(!ModelState.IsValid||entity==null)
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.Create(entity);
                if(res)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(WalletModel entity)
        {
            try
            {
                if (!ModelState.IsValid||entity==null)
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.Update(entity);
                if (res)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp);
            }
        }

        [HttpDelete]
        [Route("/{WalletId}")]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> Delete(Guid WalletId)
        {
            try
            {
                if (!ModelState.IsValid )
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.Delete(WalletId);
                if (res)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp);
            }
        }

        [HttpGet]
        [Route("/{WalletId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetByIdWithDetails(Guid WalletId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.GetByIdWithDetails(WalletId);
                if (res!=null)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp);
            }
        }

        [HttpGet]
        [Authorize(Roles ="ADMIN")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.GetAllWithDetails();
                if (res != null)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                log.LogCritical(exp.Message);
                return BadRequest(exp);
            }
        }
    }
}
