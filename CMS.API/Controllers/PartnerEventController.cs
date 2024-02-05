using Microsoft.AspNetCore.Mvc;
using CMS.API.Contracts;
using CMS.API.Entities;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerEventController : ControllerBase
    {
        private readonly IPartnerEventRepository _partnerEventRepository;

        public PartnerEventController(IPartnerEventRepository partnerEventRepository)
        {
            _partnerEventRepository = partnerEventRepository ?? throw new ArgumentNullException(nameof(partnerEventRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerEvent>>> GetPartnerEvents()
        {
            try
            {
                var partnerEvents = await _partnerEventRepository.GetPartnerEvents();
                return Ok(partnerEvents);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerEvent>> GetPartnerEventById(int id)
        {
            try
            {
                var partnerEvent = await _partnerEventRepository.GetPartnerEventById(id);

                if (partnerEvent == null)
                    return NotFound();

                return Ok(partnerEvent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePartnerEvent([FromBody] PartnerEvent partnerEvent)
        {
            try
            {
                var result = await _partnerEventRepository.CreatePartnerEvent(partnerEvent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdatePartnerEvent([FromBody] PartnerEvent partnerEvent)
        {
            try
            {
                var result = await _partnerEventRepository.UpdatePartnerEvent(partnerEvent);

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
        public async Task<ActionResult<int>> DeletePartnerEvent(int id)
        {
            try
            {
                var result = await _partnerEventRepository.DeletePartnerEvent(id);

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
