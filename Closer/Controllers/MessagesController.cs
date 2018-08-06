using Closer.DataService;
using Closer.Entities;
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
    [Route("api/v1/messages")]
    public class MessagesController : BaseController
    {
        IDataService<Message> _messageDataService;
        IDataService<Discussion> _duscussionDataService;

        public MessagesController(IDataService<Message> messageDataService, IDataService<Discussion> discussionDataService)
        {
            _duscussionDataService = discussionDataService;
            _messageDataService = messageDataService;
        }

        [HttpDelete("conversation/{conversationMoniker}/{messageMoniker}")]
        async Task<IActionResult> Delete(string conversationMoniker, string messageMoniker)
        {
            return Ok();
        }

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

            return Created(newUri, messageModel);
        }

        [HttpGet("conversation/{conversationMoniker}/{messageMoniker}", Name = "GetUnicMessage")]
        public IActionResult Get(string conversationMoniker, string messageMoniker)
        {
            return Ok();
        }

        [HttpGet("conversation/{moniker}")]
        public IActionResult Get(string moniker, int fromNumber = 0)
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
