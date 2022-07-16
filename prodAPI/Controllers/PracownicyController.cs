using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;
using System.Text.Json;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/pracownicy")]
    public class PracownicyController : Controller
    {
        private readonly ILogger<PracownicyController> _logger;
        private readonly IPracownicyRepository _pracownicyRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public PracownicyController(IPracownicyRepository pracownicyRepository, ILogger<PracownicyController> logger, IMapper mapper)
        {
            _pracownicyRepository = pracownicyRepository ?? throw new ArgumentNullException(nameof(_pracownicyRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracownicyDto>>> GetPracownicy(
            string? imie, string? email, string? nrTel,
            string? searchQuery, int pageNumber=1, int pageSize=10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (pracownicy, paginationMetadata) = await _pracownicyRepository
                .GetPracownicyAsync(imie, email, nrTel, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<PracownicyDto>>(pracownicy));   
        }
        [HttpGet("{id}", Name = "GetPracownik")]
        public async Task<ActionResult<PracownicyDto>> GetPracownicy(int id)
        { 
            var foundPracownik = await _pracownicyRepository.GetPracownicyAsync(id);
            if (foundPracownik == null)
                return NotFound();
            return Ok(foundPracownik);
        }
        [HttpPost]
        public async Task<ActionResult<PracownicyDto>> CreatePracownicy(PracownicyCreationDto Pracownik)
        {
            var newPracownik = _mapper.Map<PracownicyDto>(Pracownik);
            await _pracownicyRepository.AddPracownikAsync(newPracownik);
            await _pracownicyRepository.SaveChangesAsync();

            return CreatedAtRoute("GetPracownik",
                new
                {
                    id = newPracownik.IdPracownika
                },newPracownik); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdatePracownik(
            int id, PracownicyUpdateDto Pracownik)
        {
            var foundPracownik = await _pracownicyRepository.GetPracownicyAsync(id);
            if (foundPracownik is null)
                return NotFound();
            
            _mapper.Map(Pracownik, foundPracownik);
            await _pracownicyRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchPracownik(
            int id, JsonPatchDocument<PracownicyUpdateDto> patch)
        {
            var foundPracownik = await _pracownicyRepository.GetPracownicyAsync(id);
            if (foundPracownik is null)
                return NotFound();
            
            var pracownikToPatch = _mapper.Map<PracownicyUpdateDto>(foundPracownik);

            patch.ApplyTo(pracownikToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(pracownikToPatch))
                return BadRequest(ModelState);

            _mapper.Map(pracownikToPatch, foundPracownik);
            await _pracownicyRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePracownik(int id)
        {
            var foundPracownik = await _pracownicyRepository.GetPracownicyAsync(id);
            if (foundPracownik is null)
                return NotFound();

            _pracownicyRepository.DeletePracownik(foundPracownik);
            await _pracownicyRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
