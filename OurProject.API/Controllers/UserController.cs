//Microsoft
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

//OurProject
using OurProject.API.Domains;
using OurProject.API.Ports;
using OurProject.API.Infra;
using OurProject.API.Controllers;

//System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;

//Namespace
namespace OurProject.API.UserControllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IDatabase _database;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet("getAllUser")]
        [ProducesResponseType(typeof(IEnumerable<ReadUser>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllUser(string titleStartsWith) =>
                    Ok((await _database.GetAllUser(titleStartsWith))
                        .Select(ReadUser.FromModel).ToList());

        [HttpGet("getUserById/{id}")]
        [ProducesResponseType(typeof(ReadUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var User = await _database.GetUserById(id);
                if (User != null)
                {
                    return Ok(ReadUser.FromModel(User));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetUserById)}");
                return BadRequest(ex.Message);
            }
        }

        //Delete request for user based on ID
        [HttpDelete("removeUserById/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var User = await _database.GetUserById(id);
                if (User != null)
                {
                    await _database.DeleteUser(id);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(DeleteById)}");
                return BadRequest(ex.Message);
            }
        }

        //Put request for user changes
        [HttpPut("addEditUser/")]
        [ProducesResponseType(typeof(ReadUser), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistUser(CreateUser User)
        {
            try
            {
                var createdUser = User.ToUser();
                var persistedUser = await _database.PersistUser(createdUser);
                return CreatedAtAction(nameof(GetUserById), new { Id = createdUser.Id }, ReadUser.FromModel(persistedUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(PersistUser)}");
                return BadRequest(ex.Message);
            }
        }
    }
}