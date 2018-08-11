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
    [Route("api/v1/users")]
    public class UsersController : BaseController
    {
        IDataService<User> _userDataService;
        ISingleDataService<UserDiscussion> _userDiscussionDataService;
        IMapper _mapper;

        public UsersController(IDataService<User> userDataService, 
            ISingleDataService<UserDiscussion> userDiscussionDataService,
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
            try
            {
                var userEntity = _mapper.Map<User>(userModel);
                await _userDataService.CreateItemAsync(userEntity);

                //Create a new dynamic url for the new resource added.
                var newUri = Url.Link("GetUnicUser",
                    new { moniker = userEntity.Id });


                return Created(newUri, userModel);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _userDataService.ReadAllItemsAsync();
                var users = _mapper.Map<IEnumerable<UserModel>>(items);
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{moniker}", Name = "GetUnicUser")]
        public async Task<IActionResult> Get(string moniker)
        {
            try
            {
                var item = await _userDataService.ReadItemAsync(moniker);
                if(item != null)
                {
                    return Ok(_mapper.Map<UserModel>(item));
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
