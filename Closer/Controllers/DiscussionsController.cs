using Closer.DataService;
using Closer.Filters;
using Closer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    [ValidateModel]
    [Route("api/v1/conversations")]
    public class DiscussionsController : BaseController
    {
        IDataService<DiscussionModel> _discussionDataService;

        public DiscussionsController(IDataService<DiscussionModel> discussionDataService)
        {
            _discussionDataService = discussionDataService;
        }

        [HttpDelete("{moniker}")]
        async Task<IActionResult> Delete(string moniker)
        {
            return Ok();
        }

        [HttpPatch("{moniker}")]
        [HttpPut("{moniker}")]
        async Task<IActionResult> Put(string moniker, [FromBody]DiscussionModel discussionModel)
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]DiscussionModel discussionModel)
        {
            //Create a new dynamic url for the new resource added.
            var newUri = Url.Link("GetUnicDiscussion",
                new { moniker = discussionModel.ID });

            return Created(newUri, discussionModel);
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
