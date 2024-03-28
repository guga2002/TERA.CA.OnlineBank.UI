using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "POWEREDUSER,ADMIN")]
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
                return NotFound("Not Ffund");
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest(exp.Message);
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
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOutfromSystem()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                var res = await ser.Signout();
                return Ok(res);
            }
            return NotFound(" You are not authorized!");
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
                return NotFound("Not Found");
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            var res =await ser.Delete(Id);
            if(res)
            {
                return Ok("Succesfully deleted");
            }
            return BadRequest(" Unsacessfull  request");
        }
    }
}
