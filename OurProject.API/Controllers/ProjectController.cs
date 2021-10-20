using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OurProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(personName), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserNameById(string personName)
        {
            try
            {
                var name = await _database.GetUserNameById(personName);
                if (name != null)
                {
                    return Ok(personName.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetNameById)}");
                return BadRequest(ex.Message);
            }
        }


        /*     public async Task<IActionResult> GetUserNameById(string personName) => 
               Ok((await _database.getPersons(personName)).Select(viewPerson).ToList());
        */
    }
}
