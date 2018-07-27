using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("User Uno");
        }

        [HttpGet("{moniker}")]
        public IActionResult Get(string moniker, bool includeMessages = false, bool includeConversations = true)
        {
            try
            {
                Ok("User Uno");
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

    }
}
