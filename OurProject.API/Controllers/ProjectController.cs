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


        //userGets

        //username
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
                _logger.LogError(ex, $"Got an error for {nameof(GetUserNameById)}");
                return BadRequest(ex.Message);
            }
        }

        //email
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(personMail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserMailById(string personMail)
        {
            try
            {
                var mail = await _database.GetUserMailById(personMail);
                if (mail != null)
                {
                    return Ok(personMail.FromModel(Mail));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetUserMailById)}");
                return BadRequest(ex.Message);
            }
        }

        //DateOfBirth
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(personBirth), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserBirthById(string personBirth)
        {
            try
            {
                var birth = await _database.GetUserMailById(personBirth);
                if (birth != null)
                {
                    return Ok(personBirth.FromModel(Birth));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetUserBirthById)}");
                return BadRequest(ex.Message);
            }
        }


        //userPuts

        //username
        [HttpPut()]
        [ProducesResponseType(typeof(personName), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUser personName)
        {
            try
            {
                var createdUsername = personName.ToPerson();
                var name = await _database.CreateUser(createdUsername);
                return CreatedAtAction(nameof(GetById), new { id = createdUsername.Id.ToString() }, personName.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateUser)}");
                return BadRequest(ex.Message);
            }
        }

        //email
        [HttpPut()]
        [ProducesResponseType(typeof(personName), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMail(CreateMail personMail)
        {
            try
            {
                var createdUsermail = personMail.ToPerson();
                var mail = await _database.CreateMail(createdUsermail);
                return CreatedAtAction(nameof(GetById), new { id = createdUsermail.Id.ToString() }, personMail.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateMail)}");
                return BadRequest(ex.Message);
            }
        }

        //DateOfBirth
        [HttpPut()]
        [ProducesResponseType(typeof(personBirth), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBirth(CreateBirth personBirth)
        {
            try
            {
                var createdUserbirth = personBirth.ToPerson();
                var birth = await _database.CreateBirth(createdUserbirth);
                return CreatedAtAction(nameof(GetById), new { id = createdUserbirth.Id.ToString() }, personBirth.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateBirth)}");
                return BadRequest(ex.Message);
            }
        }


        //EventGets

        //name
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventName), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventNameById(string eventName)
        {
            try
            {
                var name = await _database.GetEventNameById(eventName);
                if (name != null)
                {
                    return Ok(eventName.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventNameById)}");
                return BadRequest(ex.Message);
            }
        }

        //date
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventDate), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventDateById(string eventDate)
        {
            try
            {
                var date = await _database.GetEventDateById(eventDate);
                if (date != null)
                {
                    return Ok(eventDate.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventDateById)}");
                return BadRequest(ex.Message);
            }
        }

        //description
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventDescription), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventDescriptionById(string eventDescription)
        {
            try
            {
                var description = await _database.GetEventDescriptionById(eventDescription);
                if (description != null)
                {
                    return Ok(eventDescription.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventDescriptionById)}");
                return BadRequest(ex.Message);
            }
        }

        //min-age
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventMinAge), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventMinAgeById(string eventMinAge)
        {
            try
            {
                var minAge = await _database.GetEventMinAgeById(eventMinAge);
                if (minAge != null)
                {
                    return Ok(eventMinAge.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventMinAgeById)}");
                return BadRequest(ex.Message);
            }
        }

        //max-age
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventMaxAge), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventMaxAgeById(string eventMaxAge)
        {
            try
            {
                var maxAge = await _database.GetEventMaxAgeById(eventMaxAge);
                if (maxAge != null)
                {
                    return Ok(eventMaxAge.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventMaxAgeById)}");
                return BadRequest(ex.Message);
            }
        }

        //enroll
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventEnroll), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventEnrollById(string eventEnroll)
        {
            try
            {
                var enroll = await _database.GetEventEnrollById(eventEnroll);
                if (enroll != null)
                {
                    return Ok(eventEnroll.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventEnrollById)}");
                return BadRequest(ex.Message);
            }
        }

        //enrollDate
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventEnroll), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventEnrollDateById(string eventEnrollDate)
        {
            try
            {
                var enrollDate = await _database.GetEventEnrollDateById(eventEnrollDate);
                if (enrollDate != null)
                {
                    return Ok(eventEnrollDate.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventEnrollDateById)}");
                return BadRequest(ex.Message);
            }
        }

        //counter
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventCounter), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventCounterById(string eventCounter)
        {
            try
            {
                var counter = await _database.GetEventCounterById(eventCounter);
                if (counter != null)
                {
                    return Ok(eventCounter.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventCounterById)}");
                return BadRequest(ex.Message);
            }
        }

        //personList
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(eventPersonList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventPersonListById(string eventPersonList)
        {
            try
            {
                var personList = await _database.GetEventCounterById(eventPersonList);
                if (personList != null)
                {
                    return Ok(eventPersonList.FromModel(Name));
                }
                else
                {
                    return NotFound();
                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(GetEventPersonListById)}");
                return BadRequest(ex.Message);
            }
        }


        //EventPuts

        //name
        [HttpPut()]
        [ProducesResponseType(typeof(eventName), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventName(CreateEventName eventName)
        {
            try
            {
                var createdName = eventName.ToPerson();
                var name = await _database.CreateUser(createdName);
                return CreatedAtAction(nameof(GetById), new { id = createdName.Id.ToString() }, eventName.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventName)}");
                return BadRequest(ex.Message);
            }
        }

        //date
        [HttpPut()]
        [ProducesResponseType(typeof(eventdate), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventDate(CreateEventDate eventDate)
        {
            try
            {
                var createdDate = eventDate.ToPerson();
                var date = await _database.CreateUser(createdDate);
                return CreatedAtAction(nameof(GetById), new { id = createdDate.Id.ToString() }, eventDate.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventDate)}");
                return BadRequest(ex.Message);
            }
        }

        //description
        [HttpPut()]
        [ProducesResponseType(typeof(eventDescription), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventDescription(CreateEventDescription eventDescription)
        {
            try
            {
                var createdDescription = eventDescription.ToPerson();
                var description = await _database.CreateUser(createdDescription);
                return CreatedAtAction(nameof(GetById), new { id = createdDescription.Id.ToString() }, eventDescription.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventDescription)}");
                return BadRequest(ex.Message);
            }
        }

        //min-age
        [HttpPut()]
        [ProducesResponseType(typeof(eventMinAge), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventMinAge(CreateEventMinAge eventMinAge)
        {
            try
            {
                var createdMinAge = eventDescription.ToPerson();
                var minAge = await _database.CreateMinAge(createdMinAge);
                return CreatedAtAction(nameof(GetById), new { id = createdMinAge.Id.ToString() }, eventMinAge.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventMinAge)}");
                return BadRequest(ex.Message);
            }
        }

        //max-age
        [HttpPut()]
        [ProducesResponseType(typeof(eventMaxAge), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventMaxAge(CreateEventMaxAge eventMaxAge)
        {
            try
            {
                var createdMaxAge = eventDescription.ToPerson();
                var maxAge = await _database.CreateMaxAge(createdMaxAge);
                return CreatedAtAction(nameof(GetById), new { id = createdMaxAge.Id.ToString() }, eventMaxAge.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventMaxAge)}");
                return BadRequest(ex.Message);
            }
        }

        //enroll
        [HttpPut()]
        [ProducesResponseType(typeof(eventEnroll), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventEnroll(CreateEventEnroll eventEnroll)
        {
            try
            {
                var createdEnroll = eventEnroll.ToPerson();
                var enroll = await _database.CreateUser(createdEnroll);
                return CreatedAtAction(nameof(GetById), new { id = createdEnroll.Id.ToString() }, eventEnroll.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventEnroll)}");
                return BadRequest(ex.Message);
            }
        }

        //enrollDate
        [HttpPut()]
        [ProducesResponseType(typeof(eventEnrollDate), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventEnrollDate(CreateEventEnrollDate eventEnrollDate)
        {
            try
            {
                var createdEnrollDate = eventEnrollDate.ToPerson();
                var enrollDate = await _database.CreateUser(createdEnrollDate);
                return CreatedAtAction(nameof(GetById), new { id = createdEnrollDate.Id.ToString() }, eventEnrollDate.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventEnrollDate)}");
                return BadRequest(ex.Message);
            }
        }

        //counter
        [HttpPut()]
        [ProducesResponseType(typeof(eventCounter), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventCounter(CreateEventCounter eventCounter)
        {
            try
            {
                var createdCounter = eventCounter.ToPerson();
                var counter = await _database.CreateUser(createdCounter);
                return CreatedAtAction(nameof(GetById), new { id = createdCounter.Id.ToString() }, eventCounter.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventCounter)}");
                return BadRequest(ex.Message);
            }
        }

        //personList
        [HttpPut()]
        [ProducesResponseType(typeof(eventPersonList), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEventPersonList(CreateEventPersonList eventPersonList)
        {
            try
            {
                var createdPersonList = eventPersonList.ToPerson();
                var personList = await _database.CreateUser(createdPersonList);
                return CreatedAtAction(nameof(GetById), new { id = createdPersonList.Id.ToString() }, eventPersonList.FromModel(name));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Got an error for {nameof(CreateEventPersonList)}");
                return BadRequest(ex.Message);
            }
        }







        /*     public async Task<IActionResult> GetUserNameById(string personName) => 
               Ok((await _database.getPersons(personName)).Select(viewPerson).ToList());
        */
    }
}
