using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        public StatusController(IStatusRepository productionRepository, ILogger<StatusController> logger, IMapper mapper)
        {
            _statusRepository = productionRepository ?? throw new ArgumentNullException(nameof(productionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatus()
        {
            var products = await _statusRepository.GetStatusAsync();
            return Ok(_mapper.Map<IEnumerable<StatusDto>>(products));
        }
        [HttpGet("{id}", Name = "GetStatus")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        { 
            var foundProduct = await _statusRepository.GetStatusAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<StatusDto>> CreateStatus(StatusCreationDto status)
        {
            var newStatus = _mapper.Map<StatusDto>(status);
            await _statusRepository.AddStatusAsync(newStatus);
            await _statusRepository.SaveChangesAsync();

            return CreatedAtRoute("GetStatus",
                new
                {
                    id = newStatus.IdStatusu
                },newStatus); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, StatusUpdateDto status)
        {
            var foundStatus = await _statusRepository.GetStatusAsync(id);
            if (foundStatus is null)
                return NotFound();
            
            _mapper.Map(status, foundStatus);
            await _statusRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<StatusUpdateDto> patch)
        {
            var foundStatus = await _statusRepository.GetStatusAsync(id);
            if (foundStatus is null)
                return NotFound();
            
            var statusToPatch = _mapper.Map<StatusUpdateDto>(foundStatus);

            patch.ApplyTo(statusToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(statusToPatch))
                return BadRequest(ModelState);

            _mapper.Map(statusToPatch, foundStatus);
            await _statusRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundStatus = await _statusRepository.GetStatusAsync(id);
            if (foundStatus is null)
                return NotFound();

            _statusRepository.DeleteStatus(foundStatus);
            await _statusRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
