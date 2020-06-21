using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.BrokenObjectLevelAuthorization
{
    [ApiController]
    [Route("bol/[controller]")]
    [Authorize]
    public class SecAccount : ControllerBase
    {

        private IAppServices appServices;

        public SecAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpGet("GetBalance/{id}")]
        public ActionResult Get(int id)
        {
            var account = appServices.GetAccount(id);

            if (account == null)
                return BadRequest();
            else
            {
                if (account.User.Username != User.FindFirst(ClaimTypes.Name).Value 
                && User.FindFirst(ClaimTypes.Role).Value != "Admin")
                    return Unauthorized();
                else
                    return Ok(account);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")] //API5
        public ActionResult Delete(int id)
        {
            var account = appServices.GetAccount(id);

            //COMPLETAR BORRADO FISICO

            if (account != null)
                return Ok("Account deleted");
            else
                return BadRequest();
        }
    }
}