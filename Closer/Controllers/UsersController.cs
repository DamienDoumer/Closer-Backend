using Closer.Models;
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
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]UserModel userModel)
        {
            //Create a new dynamic url for the new resource added.
            var newUri = Url.Link("GetUnicDiscussion",
                new { moniker = userModel.Moniker });

            return Created(newUri, userModel);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("User Uno");
        }

        [HttpGet("{moniker}", Name = "GetUnic)]
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
