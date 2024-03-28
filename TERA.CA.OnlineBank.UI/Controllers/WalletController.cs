using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(WalletModel entity)
        {
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(WalletModel entity)
        {
            return Ok();
        }
        [HttpDelete]
        [Route("/{WalletId}")]
        public async Task<IActionResult> Delete(Guid WalletId)
        {
            return Ok();
        }
        [HttpGet]
        [Route("/{WalletId}")]
        public async Task<IActionResult> GetByIdWithDetails(Guid WalletId)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return Ok();
        }
    }
}
