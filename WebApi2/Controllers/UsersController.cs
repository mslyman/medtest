using AutoMapper;
using Data.Interfaces;
using Dto;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{    
    [Route("api/v1/users")]
    public class UsersController : BaseController
    {
        private readonly IUserQuery _userQuery;
        private readonly IUserCommand _userCommand;


        public UsersController(IMapper mapper, ILoggerManager logger,
            IUserQuery userQuery,
            IUserCommand userCommand) : 
            base(mapper, logger)
        {
            _userQuery = userQuery;
            _userCommand = userCommand;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userQuery.GetListAsync();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<UserDto> GetDetails(Guid id)
        {
            return await _userQuery.GetAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Id = Guid.NewGuid();
            user.DateUpdated = DateTime.UtcNow;
            user.IsDeleted = false;

            await _userCommand.AddAsync(user);

            // See Name of GetById method
            return CreatedAtRoute("GetById", new { id = user.Id }, user); // 201  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(Guid id, [FromBody]UserDto user)
        {
            if (user == null)
            {
                _logger.LogError("User object sent from client is null.");
                return BadRequest("User object is null");
            }
            if (id != user.Id)
            {
                return BadRequest();
            }
            var existingItem = await _userQuery.GetAsync(id);
            if (existingItem == null)
            {
                _logger.LogError($"User with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            await _userCommand.UpdateAsync(user);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var existingItem = await _userQuery.GetAsync(id);
            if (existingItem == null)
            {
                _logger.LogError($"User with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            await _userCommand.RemoveAsync(id);
            return Ok(); // 204
        }
    }
}
