using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;
using System.Text.Json;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/maszyny")]
    public class MaszynyController : Controller
    {
        private readonly ILogger<MaszynyController> _logger;
        private readonly IMaszynyRepository _maszynyRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public MaszynyController(IMaszynyRepository maszynyRepository, ILogger<MaszynyController> logger, IMapper mapper)
        {
            _maszynyRepository = maszynyRepository ?? throw new ArgumentNullException(nameof(maszynyRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaszynyDto>>> GetMaszyny(
            string? nazwa, string? marka, string? model, string? kategoria,
            string? searchQuery, int pageNumber=1, int pageSize=10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (maszyny, paginationMetadata) = await _maszynyRepository
                .GetMaszynyAsync(nazwa, marka, model, kategoria, 
                searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<MaszynyDto>>(maszyny));
        }
        [HttpGet("{id}", Name = "GetMaszyna")]
        public async Task<ActionResult<MaszynyDto>> GetMaszyny(int id)
        { 
            var foundProduct = await _maszynyRepository.GetMaszynyAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<MaszynyDto>> CreateMaszyny(MaszynyCreationDto Maszyna)
        {
            var newMaszyna = _mapper.Map<MaszynyDto>(Maszyna);
            await _maszynyRepository.AddMaszynaAsync(newMaszyna);
            await _maszynyRepository.SaveChangesAsync();

            return CreatedAtRoute("GetMaszyna",
                new
                {
                    id = newMaszyna.IdMaszyny
                },newMaszyna); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, MaszynyUpdateDto Maszyna)
        {
            var foundMaszyna = await _maszynyRepository.GetMaszynyAsync(id);
            if (foundMaszyna is null)
                return NotFound();
            
            _mapper.Map(Maszyna, foundMaszyna);
            await _maszynyRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<MaszynyUpdateDto> patch)
        {
            var foundMaszyna = await _maszynyRepository.GetMaszynyAsync(id);
            if (foundMaszyna is null)
                return NotFound();
            
            var maszynaToPatch = _mapper.Map<MaszynyUpdateDto>(foundMaszyna);

            patch.ApplyTo(maszynaToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(maszynaToPatch))
                return BadRequest(ModelState);

            _mapper.Map(maszynaToPatch, foundMaszyna);
            await _maszynyRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundMaszyna = await _maszynyRepository.GetMaszynyAsync(id);
            if (foundMaszyna is null)
                return NotFound();

            _maszynyRepository.DeleteMaszyna(foundMaszyna);
            await _maszynyRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
