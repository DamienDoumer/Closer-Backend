using Closer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    [Route("api/v1/conversations")]
    public class DiscussionsController : Controller
    {

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]DiscussionModel discussionModel)
        {
            //Create a new dynamic url for the new resource added.
            var newUri = Url.Link("GetUnicDiscussion",
                new { moniker = discussionModel.Moniker });

            return Created("", new object());
        }

        [HttpGet("{moniker}", Name = "GetUnicDiscussion")]
        public IActionResult Get(string moniker)
        {
            try
            {
                Ok("Conversation Uno");
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }
    }
}
