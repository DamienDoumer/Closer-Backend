﻿using Closer.Models;
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
                new { moniker = userModel.Moniker });

            return Created(newUri, userModel);
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("User Uno");
        }

        [HttpGet("{moniker}", Name = "GetUnicUser")]
        public IActionResult Get(string moniker, bool includeMessages = false, bool includeConversations = true)
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
