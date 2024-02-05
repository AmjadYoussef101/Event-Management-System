using Microsoft.AspNetCore.Mvc;
using CMS.API.Contracts;
using CMS.API.Entities;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendanceController : ControllerBase
    {
        private readonly IEventAttendanceRepository _eventAttendanceRepository;

        public EventAttendanceController(IEventAttendanceRepository eventAttendanceRepository)
        {
            _eventAttendanceRepository = eventAttendanceRepository ?? throw new ArgumentNullException(nameof(eventAttendanceRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventAttendance>>> GetEventAttendances()
        {
            try
            {
                var eventAttendances = await _eventAttendanceRepository.GetEventAttendances();
                return Ok(eventAttendances);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventAttendance>> GetEventAttendanceById(int id)
        {
            try
            {
                var eventAttendance = await _eventAttendanceRepository.GetEventAttendanceById(id);

                if (eventAttendance == null)
                    return NotFound();

                return Ok(eventAttendance);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEventAttendance([FromBody] EventAttendance eventAttendance)
        {
            try
            {
                var result = await _eventAttendanceRepository.CreateEventAttendance(eventAttendance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateEventAttendance([FromBody] EventAttendance eventAttendance)
        {
            try
            {
                var result = await _eventAttendanceRepository.UpdateEventAttendance(eventAttendance);

                if (result == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEventAttendance(int id)
        {
            try
            {
                var result = await _eventAttendanceRepository.DeleteEventAttendance(id);

                if (result == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
