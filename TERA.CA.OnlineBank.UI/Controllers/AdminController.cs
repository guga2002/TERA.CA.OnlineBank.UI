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
        [Route("Role/{role}")]
        public async  Task<IActionResult> AddRole(string role)
        {
            try
            {
                if (!ModelState.IsValid || string.IsNullOrEmpty(role))
                {
                    logger.LogError("Name Is null There");
                    return BadRequest();
                }
                var result = await service.AddRole(role);
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
        [Route("Role")]
        public async Task<IActionResult> AsignToRole(AssignRoleModel model)
        {
            try
            {
                if(!ModelState.IsValid||model.Id is null ||model.Role is null)
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
                var res = await service.InsertCurency(entity);
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
                var res = await service.UpdateCurency(entity);
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
        public async Task<IActionResult> DeleteCurency(CurencyModel entoty)
        {
            try
            {
                if (!ModelState.IsValid || entoty.Name is null)
                {
                    logger.LogError("MoDel State Is not Valid");
                    return BadRequest();
                }
                var res = await service.DeleteCurency(entoty);
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
    }
}
