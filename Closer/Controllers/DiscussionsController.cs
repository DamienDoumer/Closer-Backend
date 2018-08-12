using AutoMapper;
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
    [Route("api/v1/conversations")]
    public class DiscussionsController : BaseController
    {
        IDataService<Discussion> _discussionDataService;
        ISingleDataService<UserDiscussion> _userDiscussionDataService;
        IMapper _mapper;

        public DiscussionsController(IDataService<Discussion> discussionDataService,
            ISingleDataService<UserDiscussion> userDiscussions, IMapper mapper)
        {
            _discussionDataService = discussionDataService;
            _userDiscussionDataService = userDiscussions;
            _mapper = mapper;
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var discussion = await _discussionDataService.ReadItemAsync(moniker);

                if (discussion == null) return NotFound();

                await _discussionDataService.DeleteItemAsync(discussion);
                return Ok();
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest("An error ocured when deleting this discussion");
        }

        [HttpPatch("{moniker}")]
        [HttpPut("{moniker}")]
        public async Task<IActionResult> Put(string moniker, [FromBody]DiscussionModel discussionModel)
        {
            try
            {
                var discussion = await _discussionDataService.ReadItemAsync(moniker);
                if (discussion != null) return NotFound();

                var newDisc = _mapper.Map<Discussion>(discussionModel);

                discussion.Title = newDisc.Title ?? discussion.Title;
                discussion.Description = newDisc.Description ?? discussion.Description;

                await _discussionDataService.UpdateItem(discussion);
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]DiscussionModel discussionModel)
        {
            try
            {
                var discussion = _mapper.Map<Discussion>(discussionModel);
                await _discussionDataService.CreateItemAsync(discussion);

                //Create a new dynamic url for the new resource added.
                var newUri = Url.Link("GetUnicDiscussion",
                    new { moniker = discussion.Id });

                discussionModel.ID = discussion.Moniker;
                return Created(newUri, discussionModel);
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _discussionDataService.ReadAllItemsAsync();
                return Ok(_mapper.Map<IEnumerable<DiscussionModel>>(items));
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }

        [HttpGet("{moniker}", Name = "GetUnicDiscussion")]
        public async Task<IActionResult> Get(string moniker)
        {
            try
            {
                var item = await _discussionDataService.ReadItemAsync(moniker);
                if (item == null) return NotFound("This discussion was not found.");

                return Ok(_mapper.Map<DiscussionModel>(item));
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest();
        }
    }
}
