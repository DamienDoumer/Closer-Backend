using Closer.Entities;
using Closer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Controllers
{
    [Route("api/v1/messages")]
    public class MessagesController : Controller
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]MessageModel messageModel)
        {
            //Create a new dynamic url for the new resource added.
            var newUri = Url.Link("GetUnicMessage",
                new { conversationMoniker = messageModel.ConversationMoniker, messageMoniker = messageModel.Moniker });

            return Created("", new object());
        }

        [HttpGet("conversation/{conversationMoniker}/{messageMoniker}", Name = "GetUnicMessage")]
        public IActionResult Get(string conversationMoniker, string messageMoniker)
        {
            return Ok();
        }

        [HttpGet("conversation/{moniker}")]
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
