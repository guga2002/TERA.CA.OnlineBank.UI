using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                    return NotFound();
                }
                logger.LogInformation("Successfully  add role to DB");
                return Ok(result); 
            }
            catch (Exception exp)
            {
                logger.LogCritical(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                var res = await service.AsignToRole(model);
                if(!res)
                {
                    logger.LogCritical("no role assigned");
                    return BadRequest();
                }
                logger.LogInformation("Successfully assigned role");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                var res = await service.Create(entity);
                if (!res)
                {
                    logger.LogCritical("No Curency inserted to db");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Inserted");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("Currency")]
        public async Task<IActionResult> GellAllCurency()
        {
            try
            {
                var res = await service.GetAll();
                if (res!=null)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("Currency/{Id}")]
        public async Task<IActionResult> GetAllById(Guid Id)
        {
            try
            {
                var res = await service.GetById(Id);
                if (res != null)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                var res = await service.Update(entity);
                if (!res)
                {
                    logger.LogCritical("No Curency Updated to db");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Updated!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("Currency")]
        public async Task<IActionResult> DeleteCurency(Guid entoty)
        {
            try
            {
                if (!ModelState.IsValid )
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest();
                }
                var res = await service.Delete(entoty);
                if (!res)
                {
                    logger.LogCritical("No Curency Deleted to db");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Deleted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
            }
        }
        [HttpPatch]
        [Route("User")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel entity)
        {
            try
            {
                var res = await service.ResetPassword(entity);
                if (!res)
                {
                    logger.LogCritical("No password Reseted");
                    return BadRequest();
                }
                logger.LogInformation("Successfully Reseted!");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                logger.LogInformation("User Modified");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                logger.LogInformation("Transactiontype Modified");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return BadRequest();
                }
                logger.LogInformation("Transactiontype Deleted");
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
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
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception exp)
            {
                logger.LogError(exp.Message);
                return BadRequest();
            }
        }
    }
}
