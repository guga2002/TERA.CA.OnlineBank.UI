using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="POWEREDUSER")]
    public class UserController : ControllerBase
    {
       [HttpPut]
       [Route("Auth")]
       [AllowAnonymous]
       public async Task<IActionResult> SignIn(SignInModel model)
        {
            return Ok();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel user)
        {
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> EditProfile(UserModel mod)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProfileInfo()
        {
            return Ok();
        }
    }
}
