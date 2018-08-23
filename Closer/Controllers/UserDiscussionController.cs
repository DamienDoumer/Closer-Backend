using AutoMapper;
using Closer.DataService;
using Closer.Entities;
using Closer.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        IDataService<Discussion> _discussionDataService;
        ISingleDataService<UserDiscussion> _userDiscussionDataService;
        IMapper _mapper;
        protected ILogger<UserDiscussionController> _logger;

        public UserDiscussionController(IDataService<Discussion> discussion, 
            ISingleDataService<UserDiscussion> userDiscussion, IMapper mapper, ILogger<UserDiscussionController> logger) 
        {
            _mapper = mapper;
            _userDiscussionDataService = userDiscussion;
            _mapper = mapper;
        }

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
        public async Task<IActionResult> Delete(string conversationMoniker, string userMoniker)
        {
            try
            {
                await _userDiscussionDataService.PersonalizedDeleteQuery(d => (Convert.ToString(d.DiscussionId) == conversationMoniker && 
                        Convert.ToString(d.UserId) == userMoniker));

                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error occured while removing the user with moniker: {userMoniker} from conversation with moniker : {conversationMoniker}");
            }

            _logger.LogWarning($"removing the user with moniker: {userMoniker} from conversation with moniker : {conversationMoniker} was not completed.");
            return BadRequest();
        }

        [HttpPost("conversation/{conversationMoniker}/{userMoniker}")]
        public async Task<IActionResult> Post(string conversationMoniker, string userMoniker)
        {
            try
            {
                if ((await _userDiscussionDataService.PersonalizedQuery(d => (Convert.ToString(d.DiscussionId) == conversationMoniker &&
                         Convert.ToString(d.UserId) == userMoniker))) != null) return BadRequest("This user is already into this conversation.");

                await _userDiscussionDataService.CreateItemAsync(new UserDiscussion
                    { UserId = Convert.ToInt32(userMoniker),
                        DiscussionId = Convert.ToInt32(userMoniker) });

                return Ok();
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest("Could not insert this user into this conversation.");
        }
    }
}
