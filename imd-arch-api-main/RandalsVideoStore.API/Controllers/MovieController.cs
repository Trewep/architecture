using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandalsVideoStore.API.Ports;

namespace RandalsVideoStore.API.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        // noticce we don't care about our actual database implementation; we just pass an interface (== contract)
        private readonly IDatabase _database;

        // everything you use on _logger will end up on STDOUT (the terminal where you started your process)
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IDatabase database)
        {
            _database = database;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewMovie>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string titleStartsWith) =>
            Ok((await _database.GetAllMovies(titleStartsWith))
                .Select(ViewMovie.FromModel).ToList());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViewMovie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var movie = await _database.GetMovieById(Guid.Parse(id));
                if (movie != null)
                {
                    return Ok(ViewMovie.FromModel(movie));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // This is just good practice; you never want to expose a raw exception message. There are some libraries/services to handle this
                // but it's better to take full control of your code.
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(string id)
        {
            try
            {
                var parsedId = Guid.Parse(id);
                var movie = await _database.GetMovieById(parsedId);
                if (movie != null)
                {
                    await _database.DeleteMovie(parsedId);
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

        [HttpPut()]
        [ProducesResponseType(typeof(ViewMovie), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PersistMovie(CreateMovie movie)
        {
            try
            {
                var createdMovie = movie.ToMovie();
                var persistedMovie = await _database.PersistMovie(createdMovie);
                return CreatedAtAction(nameof(GetById), new { id = createdMovie.Id.ToString() }, ViewMovie.FromModel(persistedMovie));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(PersistMovie)}");
                return BadRequest(ex.Message);
            }
        }
    }

}
