using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TERA.Ca.OnlineBank.Domain.Interfaces;
using TERA.Ca.OnlineBank.Domain.Models;

namespace TERA.CA.OnlineBank.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminPanell service;
        private readonly ILogger<AdminController> logger;
        public AdminController(IAdminPanell Serv,ILogger<AdminController> Logger)
        {
            this.service = Serv;
            this.logger = Logger;
        }

        [HttpGet("CurencUserIDJustForTesting")]
        [AllowAnonymous]
        public IActionResult testing()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(userId);
        }
        [HttpPost]
        [Route("Role/{roleName}")]
        public async  Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                if (!ModelState.IsValid || string.IsNullOrEmpty(roleName))
                {
                    logger.LogError("Name Is null There");
                    return BadRequest();
                }
                var result = await service.AddRole(roleName);
                if(!result)
                {
                    return NotFound("not found");
                }
                logger.LogInformation("Successfully  add role to DB");
                return Ok(result); 
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest(exp.Message);
            }

        }

        [HttpPost]
        [Route("Role/Assign")]
        public async Task<IActionResult> AsignToRole(AssignRoleModel model)
        {
            try
            {
                if(!ModelState.IsValid||model.UserID is null ||model.Role is null)
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest("MoDel State Is not Valid");
                }
                var res = await service.AsignToRole(model);
                if(!res)
                {
                    logger.LogCritical("no role assigned");
                    return BadRequest("no role assigned");
                }
                logger.LogInformation("Successfully assigned role");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        [Route("Currency")]
        public async Task<IActionResult> InsertCurency(CurencyModel entity)
        {
            try
            {
                if (!ModelState.IsValid || entity.Name is null)
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest("MoDel State Is not Valid");
                }
                var res = await service.Create(entity);
                if (!res)
                {
                    logger.LogCritical("No Curency inserted to db");
                    return BadRequest("No Curency inserted to db");
                }
                logger.LogInformation("Successfully Inserted");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }

        }
        [HttpGet]
        [Route("Currency")]
        [AllowAnonymous]
        public async Task<IActionResult> GellAllCurency()
        {
            try
            {
                var res = await service.GetAll();
                if (res==null)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest("No Curency Deleted to db");
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }

        }

        [HttpGet]
        [Route("Currency/{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllById(Guid Id)
        {
            try
            {
                var res = await service.GetById(Id);
                if (res != null)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest("No Curency Deleted to db");
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }

        }

        [HttpPut]
        [Route("Currency")]
        public async Task<IActionResult> UpdateCurency(CurencyModel entity)
        {
            try
            {
                if (!ModelState.IsValid || entity.Name is null)
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest("MoDel State Is not Valid");
                }
                var res = await service.Update(entity);
                if (!res)
                {
                    logger.LogCritical("No Curency Updated to db");
                    return BadRequest("No Curency Updated to db");
                }
                logger.LogInformation("Successfully Updated!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
        [HttpDelete]
        [Route("Currency/{Id}")]
        public async Task<IActionResult> DeleteCurency(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid )
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest("MoDel State Is not Valid");
                }
                var res = await service.Delete(Id);
                if (!res)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest("No Curency Deleted to db");
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
        [HttpPatch]
        [Route("User")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel entity)
        {
            try
            {
                var res = await service.ResetPassword(entity);
                if (res==false)
                {
                    logger.LogCritical("No password Reseted");
                    return BadRequest("No password Reseted");
                }
                logger.LogInformation("Successfully Reseted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
        [HttpPut]
        [Route("User/{PersonalNumber}")]
        public async Task<IActionResult> updateUserData(string PersonalNumber,UserModel entity)
        {
            try
            {
                var res = await service.ModifyUser(PersonalNumber,entity);
                if (!res)
                {
                    logger.LogCritical("No user Modified");
                    return BadRequest("No user Modified");
                }
                logger.LogInformation("User Modified");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }

        }

        [HttpPost]
        [Route("TransactionType")]
        public async Task<IActionResult> CreateTransactionType(TransactionTypeModel entity)
        {
            try
            {
                var res = await service.CreateTransactionType(entity);
                if (!res)
                {
                    logger.LogCritical("No TransactionType Modified");
                    return BadRequest("No TransactionType Modified");
                }
                logger.LogInformation("Transactiontype Modified");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        [Route("TransactionType")]
        public async Task<IActionResult> DeleteTransactionType(TransactionTypeModel entoty)
        {
            try
            {
                var res = await service.DeleteTransactionType(entoty);
                if (!res)
                {
                    logger.LogCritical("No TransactionType Deleted");
                    return BadRequest("No TransactionType Deleted");
                }
                logger.LogInformation("Transactiontype Deleted");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("TransactionType/{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdTransactionType(string Id)
        {
            try
            {
                var res = await service.GetByIdTransactionType(Id);
                if (res == null)
                {
                    logger.LogInformation("No records exist");
                    return NotFound("No records exist");
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest(exp.Message);
            }
        }
    }
}
