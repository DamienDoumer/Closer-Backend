using Closer.DataService;
using Closer.DataService.EF;
using Closer.Entities;
using Closer.Filters;
using Closer.Helpers;
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
        IDataService<Discussion> _discussionDataService;

        public MessagesController(IDataService<Message> messageDataService, IDataService<Discussion> discussionDataService)
        {
            _discussionDataService = discussionDataService;
            _messageDataService = messageDataService;
        }

        [HttpDelete("conversation/{conversationMoniker}/{messageMoniker}")]
        async Task<IActionResult> Delete(string conversationMoniker, string messageMoniker)
        {
            try
            {
                var message = _messageDataService.ReadItemAsync(messageMoniker);
                if (message == null) return NotFound();

                await _messageDataService.PersonalizedDeleteQuery(msg => msg.Id == Convert.ToInt32(messageMoniker));

            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var messages = await _messageDataService.ReadAllItemsAsync();

                return Ok(messages);
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
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
            try
            {
                var message = _messageDataService.ReadItemAsync(messageMoniker);

                if (message == null) return NotFound();

                return Ok(message);
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

        [HttpGet("conversation/{moniker}")]
        public async Task<IActionResult> Get(string moniker, int fromNumber = 0)
        {
            try
            {
                var messages = (await _messageDataService.PersonalizedQuery(msg => msg.MessageDiscussionId == Convert.ToInt32(moniker)))
                    .Skip(fromNumber).Take(Utilities.PAGE_SIZE);

                return Ok(messages);
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }
    }
}
