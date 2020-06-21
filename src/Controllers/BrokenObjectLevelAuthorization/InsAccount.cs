using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.BrokenObjectLevelAuthorization
{
    [ApiController]
    [Route("bol/[controller]")]
    public class InsAccount : ControllerBase
    {

        private IAppServices appServices;

        public InsAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpGet("GetBalance/{id}")]
        public ActionResult Get(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
                return Ok(account);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var account = appServices.GetAccount(id);

            if (account != null)
                return Ok($"Account \"{ account.User.Username }\" deleted - Muy común ver en apis autogeneradas");
            else
                return BadRequest();
        }
    }
}