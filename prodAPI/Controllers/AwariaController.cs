using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using prodAPI.Models;
using prodAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/awaria")]
    public class AwariaController : Controller
    {
        private readonly ILogger<AwariaController> _logger;
        private readonly IAwariaRepository _awariaRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public AwariaController(IAwariaRepository awariaRepository, ILogger<AwariaController> logger, IMapper mapper)
        {
            _awariaRepository = awariaRepository ?? throw new ArgumentNullException(nameof(awariaRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwariaDto>>> GetAwaria(
            DateTime? dataZgloszenia, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (awaria,paginationMetadata) = await _awariaRepository
                .GetAwariaAsync(dataZgloszenia, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<AwariaDto>>(awaria));
        }
        [HttpGet("{id}", Name = "GetAwaria")]
        public async Task<ActionResult<AwariaDto>> GetAwaria(int id)
        { 
            var foundProduct = await _awariaRepository.GetAwariaAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<AwariaDto>> CreateAwaria(AwariaCreationDto surowiec)
        {
            var newAwaria = _mapper.Map<AwariaDto>(surowiec);
            await _awariaRepository.AddAwariaAsync(newAwaria);
            await _awariaRepository.SaveChangesAsync();

            return CreatedAtRoute("GetAwaria",
                new
                {
                    id = newAwaria.IdAwarii
                },newAwaria); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, AwariaUpdateDto surowiec)
        {
            var foundAwaria = await _awariaRepository.GetAwariaAsync(id);
            if (foundAwaria is null)
                return NotFound();
            
            _mapper.Map(surowiec, foundAwaria);
            await _awariaRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<AwariaUpdateDto> patch)
        {
            var foundAwaria = await _awariaRepository.GetAwariaAsync(id);
            if (foundAwaria is null)
                return NotFound();
            
            var surowiecToPatch = _mapper.Map<AwariaUpdateDto>(foundAwaria);

            patch.ApplyTo(surowiecToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(surowiecToPatch))
                return BadRequest(ModelState);

            _mapper.Map(surowiecToPatch, foundAwaria);
            await _awariaRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundAwaria = await _awariaRepository.GetAwariaAsync(id);
            if (foundAwaria is null)
                return NotFound();

            _awariaRepository.DeleteAwaria(foundAwaria);
            await _awariaRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
