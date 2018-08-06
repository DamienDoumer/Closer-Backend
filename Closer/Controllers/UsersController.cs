using AutoMapper;
using Closer.DataService;
using Closer.Entities;
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
        IDataService<User> _userDataService;
        IDataService<UserDiscussion> _userDiscussionDataService;
        IMapper _mapper;

        public UsersController(IDataService<User> userDataService, 
            IDataService<UserDiscussion> userDiscussionDataService,
            IMapper mapper)
        {
            _mapper = mapper;
            _userDataService = userDataService;
            _userDiscussionDataService = userDiscussionDataService;
        }

        [HttpDelete("{moniker}")]
        async Task<IActionResult> Delete(string moniker)
        {
            return Ok();
        }

        [HttpPatch("{moniker}")]
        [HttpPut("{moniker}")]
        async Task<IActionResult> Put(string moniker, [FromBody]UserModel userModel)
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]UserModel userModel)
        {
            //Create a new dynamic url for the new resource added.
            var newUri = Url.Link("GetUnicUser",
                new { moniker = userModel.ID });

            return Created(newUri, userModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
           var items = await _userDataService.ReadAllItemsAsync();
        }

        [HttpGet("{moniker}", Name = "GetUnicUser")]
        public IActionResult Get(string moniker, bool includeDiscussions = true)
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
