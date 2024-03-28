using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="POWEREDUSER")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices ser;
        private readonly ILogger<UserController> logger;
        public UserController(IUserServices ser, ILogger<UserController> logger)
        {
            this.ser = ser;
            this.logger = logger;
        }

       [HttpPut]
       [Route("Auth")]
       [AllowAnonymous]
       public async Task<IActionResult> SignIn(SignInModel model)
        {
            try
            {
                var res = await ser.SignIn(model);
                if (res)
                {
                    logger.LogInformation($"{model} Succesfully Signedin");
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel user)
        {
            try
            {
                var res = await ser.Register(user);
                if (res)
                {
                    logger.LogInformation($"{user} Succesfully Registered");
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }
        [HttpPatch]
        public async Task<IActionResult> EditProfile(UserModel mod)
        {
            try
            {
                var res = await ser.Update(mod);
                if (res)
                {
                    logger.LogInformation($"{mod} Succesfully Edited");
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
            }
        }
    }
}
