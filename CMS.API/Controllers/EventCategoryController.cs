using Microsoft.AspNetCore.Mvc;
using CMS.API.Contracts;
using CMS.API.Entities;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public EventCategoryController(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository ?? throw new ArgumentNullException(nameof(eventCategoryRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventCategory>>> GetEventCategories()
        {
            try
            {
                var eventCategories = await _eventCategoryRepository.GetEventCategories();
                return Ok(eventCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventCategory>> GetEventCategoryById(int id)
        {
            try
            {
                var eventCategory = await _eventCategoryRepository.GetEventCategoryById(id);

                if (eventCategory == null)
                    return NotFound();

                return Ok(eventCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEventCategory([FromBody] EventCategory eventCategory)
        {
            try
            {
                var result = await _eventCategoryRepository.CreateEventCategory(eventCategory);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateEventCategory([FromBody] EventCategory eventCategory)
        {
            try
            {
                var result = await _eventCategoryRepository.UpdateEventCategory(eventCategory);

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
        public async Task<ActionResult<int>> DeleteEventCategory(int id)
        {
            try
            {
                var result = await _eventCategoryRepository.DeleteEventCategory(id);

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
