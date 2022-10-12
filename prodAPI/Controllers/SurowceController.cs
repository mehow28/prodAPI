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
    [Route("api/surowce")]
    public class SurowceController : Controller
    {
        private readonly ILogger<SurowceController> _logger;
        private readonly ISurowceRepository _surowceRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public SurowceController(ISurowceRepository surowceRepository, ILogger<SurowceController> logger, IMapper mapper)
        {
            _surowceRepository = surowceRepository ?? throw new ArgumentNullException(nameof(surowceRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurowceDto>>> GetSurowce(
            string? nazwa, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (surowce,paginationMetadata) = await _surowceRepository
                .GetSurowceAsync(nazwa, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<SurowceDto>>(surowce));
        }
        [HttpGet("{id}", Name = "GetSurowiec")]
        public async Task<ActionResult<SurowceDto>> GetSurowce(int id)
        { 
            var foundProduct = await _surowceRepository.GetSurowceAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<SurowceDto>> CreateSurowce(SurowceCreationDto surowiec)
        {
            var newSurowiec = _mapper.Map<SurowceDto>(surowiec);
            await _surowceRepository.AddSurowiecAsync(newSurowiec);
            await _surowceRepository.SaveChangesAsync();

            return CreatedAtRoute("GetSurowiec",
                new
                {
                    id = newSurowiec.IdSurowca
                },newSurowiec); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, SurowceUpdateDto surowiec)
        {
            var foundSurowiec = await _surowceRepository.GetSurowceAsync(id);
            if (foundSurowiec is null)
                return NotFound();
            
            _mapper.Map(surowiec, foundSurowiec);
            await _surowceRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<SurowceUpdateDto> patch)
        {
            var foundSurowiec = await _surowceRepository.GetSurowceAsync(id);
            if (foundSurowiec is null)
                return NotFound();
            
            var surowiecToPatch = _mapper.Map<SurowceUpdateDto>(foundSurowiec);

            patch.ApplyTo(surowiecToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(surowiecToPatch))
                return BadRequest(ModelState);

            _mapper.Map(surowiecToPatch, foundSurowiec);
            await _surowceRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundSurowiec = await _surowceRepository.GetSurowceAsync(id);
            if (foundSurowiec is null)
                return NotFound();

            _surowceRepository.DeleteSurowiec(foundSurowiec);
            await _surowceRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
