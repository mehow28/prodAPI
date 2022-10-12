using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;
using System.Text.Json;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/surowcedlaetapu")]
    public class SurowceDlaEtapuController : Controller
    {
        private readonly ILogger<SurowceDlaEtapuController> _logger;
        private readonly ISurowceDlaEtapuRepository _pdeRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public SurowceDlaEtapuController(ISurowceDlaEtapuRepository pdeRepository, ILogger<SurowceDlaEtapuController> logger, IMapper mapper)
        {
            _pdeRepository = pdeRepository ?? throw new ArgumentNullException(nameof(pdeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurowceDlaEtapuDto>>> GetPdes(
            int? idSurowca, int? idEtapu,
            int pageNumber=1, int pageSize=10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (pdes, paginationMetadata) = await _pdeRepository
                .GetSurowceDlaEtapuAsync(idEtapu, idSurowca, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(pdes);
        }
        [HttpGet("{id}", Name = "GetPde")]
        public async Task<ActionResult<EtapyDto>> GetPde(int id)
        {
            var foundPde = await _pdeRepository.GetSurowiecDlaEtapuAsync(id);
            if (foundPde == null)
                return NotFound();
            return Ok(foundPde);
        }
        [HttpPost]
        public async Task<ActionResult<SurowceDlaEtapuDto>> CreatePde(SurowceDlaEtapuCreationDto pde)
        {
            var newPde = _mapper.Map<SurowceDlaEtapuDto>(pde);
            await _pdeRepository.AddSurowceDlaEtapuAsync(newPde);
            await _pdeRepository.SaveChangesAsync();

            return CreatedAtRoute("GetEtap",
                new
                {
                    id = newPde.Id
                }, newPde); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePde(
            int id, SurowceDlaEtapuUpdateDto pde)
        {
            var foundPde = await _pdeRepository.GetSurowiecDlaEtapuAsync(id);
            if (foundPde is null)
                return NotFound();

            _mapper.Map(pde, foundPde);
            await _pdeRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchPde(
            int id, JsonPatchDocument<SurowceDlaEtapuUpdateDto> patch)
        {
            var foundPde = await _pdeRepository.GetSurowiecDlaEtapuAsync(id);
            if (foundPde is null)
                return NotFound();

            var pdeToPatch = _mapper.Map<SurowceDlaEtapuUpdateDto>(foundPde);

            patch.ApplyTo(pdeToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(pdeToPatch))
                return BadRequest(ModelState);

            _mapper.Map(pdeToPatch, foundPde);
            await _pdeRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePde(int id)
        {
            var foundPde = await _pdeRepository.GetSurowiecDlaEtapuAsync(id);
            if (foundPde is null)
                return NotFound();

            _pdeRepository.DeleteSurowceDlaEtapu(foundPde);
            await _pdeRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
