using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Interfaces;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticServices ser;
        private readonly ILogger<StatisticController> Logger;

        public StatisticController(IStatisticServices ser, ILogger<StatisticController> Logger)
        {
            this.ser = ser;
            this.Logger = Logger;
        }

        [HttpGet]
        [Route("Popular/{count}")]
        public async Task<IActionResult> GetMostPopulatTransactionsTypes(int count)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return NotFound();
                }
                var res=await ser.GetMostPopulatTransactionsTypes(count);
                if(res.Count()==0)
                {
                    Logger.LogCritical("No Transactions exist");
                    return NotFound("No Transactions exist");
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                Logger.LogCritical(exp.StackTrace);
                return BadRequest(exp.Message);
            }
        }
        [HttpGet]
        [Route("Popular/Transaction{type}")]
        public async Task<IActionResult> GetTransactionsByTransactionType(string type)
        {
            try
            {

                if (!ModelState.IsValid || string.IsNullOrEmpty(type))
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.GetTransactionsByTransactionType(type);
                if (res.Count() == 0)
                {
                    Logger.LogInformation($"CHanaweri ar moidzebba  tranzaqciis tippshi{type}");
                    return NotFound("No data exist");
                }
                return Ok(res);

            }
            catch (Exception exp)
            {
                Logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
        [HttpGet]
        [Route("Popular/{start}/{end}")]
        public async Task<IActionResult> GetTransactonsByPeriod(DateTime start, DateTime end)
        {
            try
            {

                if (!ModelState.IsValid || start>=end)
                {
                    return BadRequest(ModelState);
                }
                var res = await ser.GetTransactonsByPeriod(start,end);
                if (res.Count() == 0)
                {
                    Logger.LogInformation($"CHanaweri ar moidzebba  tranzaqcibi am prsiodshi {start}- {end}");
                    return NotFound("No data exist");
                }
                return Ok(res);

            }
            catch (Exception exp)
            {
                Logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }

        }
    }
}
