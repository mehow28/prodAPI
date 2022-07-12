using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/etapy")]
    public class EtapyController : Controller
    {
        private readonly ILogger<EtapyController> _logger;
        private readonly IEtapyRepository _etapyRepository;
        private readonly IMapper _mapper;
        public EtapyController(IEtapyRepository etapyRepository, ILogger<EtapyController> logger, IMapper mapper)
        {
            _etapyRepository = etapyRepository ?? throw new ArgumentNullException(nameof(etapyRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtapyDto>>> GetEtapy()
        {
            var etapy = await _etapyRepository.GetEtapyAsync();
            return Ok(etapy);
        }
        [HttpGet("{id}", Name = "GetEtap")]
        public async Task<ActionResult<EtapyDto>> GetEtap(int id)
        {
            var foundEtap = await _etapyRepository.GetEtapyAsync(id);
            if (foundEtap == null)
                return NotFound();
            return Ok(foundEtap);
        }
        [HttpPost]
        public async Task<ActionResult<EtapyDto>> CreateEtap(EtapyCreationDto etap)
        {
            var newEtap = _mapper.Map<EtapyDto>(etap);
            await _etapyRepository.AddEtapAsync(newEtap);
            await _etapyRepository.SaveChangesAsync();

            return CreatedAtRoute("GetEtap",
                new
                {
                    id = newEtap.IdProduktu
                }, newEtap); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEtap(
            int id, EtapyUpdateDto Etap)
        {
            var foundEtap = await _etapyRepository.GetEtapyAsync(id);
            if (foundEtap is null)
                return NotFound();

            _mapper.Map(Etap, foundEtap);
            await _etapyRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchEtap(
            int id, JsonPatchDocument<EtapyUpdateDto> patch)
        {
            var foundEtap = await _etapyRepository.GetEtapyAsync(id);
            if (foundEtap is null)
                return NotFound();

            var etapToPatch = _mapper.Map<EtapyUpdateDto>(foundEtap);

            patch.ApplyTo(etapToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(etapToPatch))
                return BadRequest(ModelState);

            _mapper.Map(etapToPatch, foundEtap);
            await _etapyRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEtap(int id)
        {
            var foundEtap = await _etapyRepository.GetEtapyAsync(id);
            if (foundEtap is null)
                return NotFound();

            _etapyRepository.DeleteEtap(foundEtap);
            await _etapyRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
