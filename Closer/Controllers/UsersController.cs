using AutoMapper;
using Closer.DataService;
using Closer.Entities;
using Closer.Filters;
using Closer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        protected ILogger<UsersController> _logger;

        public UsersController(IDataService<User> userDataService, 
            ISingleDataService<UserDiscussion> userDiscussionDataService,
            IMapper mapper, ILogger<UsersController> logger)
        {
            _mapper = mapper;
            _userDataService = userDataService;
            _userDiscussionDataService = userDiscussionDataService;
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var user = await _userDataService.ReadItemAsync(moniker);

                if (user != null) return NotFound();

                await _userDataService.DeleteItemAsync(user);
                return Ok();
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest("An error occured when deleting this user.");
        }

        [HttpPatch("{moniker}")]
        [HttpPut("{moniker}")]
        public async Task<IActionResult> Put(string moniker, [FromBody]UserModel userModel)
        {
            try
            {
                var user = await _userDataService.ReadItemAsync(moniker);

                if (user != null)
                {
                    var newUser = _mapper.Map<User>(userModel);

                    user.Name = userModel.Name ?? user.Name;
                    user.Pseudo = userModel.Pseudo ?? user.Pseudo;
                    user.Bio = userModel.Bio ?? user.Bio;
                    user.Email = userModel.Email ?? user.Email;
                    user.Password = userModel.Password ?? user.Password;

                    await _userDataService.UpdateItem(user);

                    return Ok(user);
                }
                else
                {
                    return NotFound($"The user with ID : {userModel.ID} could not be found.");
                }
            }
            catch (Exception e)
            {
                ;
            }

            return BadRequest("Couldn't update user.");
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

                userModel.ID = userEntity.Moniker;
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
                return BadRequest();
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
