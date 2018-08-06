using Closer.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    [ValidateModel]
    [Route("api/v1/user_discussion")]
    public class UserDiscussionController : BaseController
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// When a user quits a conversation
        /// </summary>
        /// <param name="conversationMoniker"></param>
        /// <param name="messageMoniker"></param>
        /// <returns></returns>
        [HttpDelete("conversation/{conversationMoniker}/{userMoniker}")]
        async Task<IActionResult> Delete(string conversationMoniker, string userMoniker)
        {
            return Ok();
        }
    }
}
