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
namespace OurProject.API.EventControllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IDatabase _database;
        private readonly ILogger<EventController> _logger;
        public EventController(ILogger<EventController> logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet("getAllEvents")]
        [ProducesResponseType(typeof(IEnumerable<ReadEvent>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllEvents(string titleStartsWith) =>
          Ok((await _database.GetAllEvents(titleStartsWith))
              .Select(ReadEvent.FromModel).ToList());

        //Get request for event based on id
        [HttpGet("getEventById/{id}")]
        [ProducesResponseType(typeof(ReadEvent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventById(int id)
        {
            try
            {
                var event_ = await _database.GetEventById(id);
                if (event_ != null)
                {
                    return Ok(ReadEvent.FromModel(event_));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventById)}");
                return BadRequest(ex.Message);
            }
        }

        //Delete request for event based on id
        [HttpDelete("removeEventById/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var event_ = await _database.GetEventById(id);
                if (event_ != null)
                {
                    await _database.DeleteEvent(id);
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

        //Put request for event
        [HttpPut("addEditEvent")]
        [ProducesResponseType(typeof(ReadEvent), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistEvent(CreateEvent event_)
        {
            try
            {
                var createdEvent = event_.ToEvent();
                var persistedEvent = await _database.PersistEvent(createdEvent);
                return CreatedAtAction(nameof(GetEventById), new { Id = createdEvent.Id }, ReadEvent.FromModel(persistedEvent));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(PersistEvent)}");
                return BadRequest(ex.Message);
            }
        }
    }
}