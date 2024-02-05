using Microsoft.AspNetCore.Mvc;
using CMS.API.Contracts;
using CMS.API.Entities;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorEventController : ControllerBase
    {
        private readonly ISponsorEventRepository _sponsorEventRepository;

        public SponsorEventController(ISponsorEventRepository sponsorEventRepository)
        {
            _sponsorEventRepository = sponsorEventRepository ?? throw new ArgumentNullException(nameof(sponsorEventRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SponsorEvent>>> GetSponsorEvents()
        {
            try
            {
                var sponsorEvents = await _sponsorEventRepository.GetSponsorEvents();
                return Ok(sponsorEvents);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SponsorEvent>> GetSponsorEventById(int id)
        {
            try
            {
                var sponsorEvent = await _sponsorEventRepository.GetSponsorEventById(id);

                if (sponsorEvent == null)
                    return NotFound();

                return Ok(sponsorEvent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateSponsorEvent([FromBody] SponsorEvent sponsorEvent)
        {
            try
            {
                var result = await _sponsorEventRepository.CreateSponsorEvent(sponsorEvent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateSponsorEvent([FromBody] SponsorEvent sponsorEvent)
        {
            try
            {
                var result = await _sponsorEventRepository.UpdateSponsorEvent(sponsorEvent);

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
        public async Task<ActionResult<int>> DeleteSponsorEvent(int id)
        {
            try
            {
                var result = await _sponsorEventRepository.DeleteSponsorEvent(id);

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
