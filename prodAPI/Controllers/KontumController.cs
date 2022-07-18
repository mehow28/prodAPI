using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/konta")]
    public class KontumController : Controller
    {
        /*KONTROLER NIEUŻYWALNY PRZED ZAIMPLEMENTOWANIEM HASHOWANIA*/
        private readonly ILogger<KontumController> _logger;
        private readonly IKontumRepository _kontumRepository;
        private readonly IMapper _mapper;
        public KontumController(IKontumRepository kontumRepository, ILogger<KontumController> logger, IMapper mapper)
        {
            _kontumRepository = kontumRepository ?? throw new ArgumentNullException(nameof(kontumRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KontumDto>>> GetKontum()
        {
            var kontum = await _kontumRepository.GetKontumAsync();
            return Ok(kontum);
        }
        [HttpGet("{id}", Name = "GetKontum")]
        public async Task<ActionResult<KontumDto>> GetKontum(int id)
        {
            var foundKontum = await _kontumRepository.GetKontumAsync(id);
            if (foundKontum == null)
                return NotFound();
            return Ok(foundKontum);
        }
        [HttpPost]
        public async Task<ActionResult<KontumDto>> CreateKontum(KontumCreationDto kontum)
        {
            var newKontum = _mapper.Map<KontumDto>(kontum);
            await _kontumRepository.AddKontoAsync(kontum);
            await _kontumRepository.SaveChangesAsync();

            return CreatedAtRoute("GetKontum",
                new
                {
                    id = newKontum.IdKonta
                }, newKontum); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateKontum(
            int id, KontumUpdateDto kontum)
        {
            var foundKontum = await _kontumRepository.GetKontumAsync(id);
            if (foundKontum is null)
                return NotFound();

            _mapper.Map(kontum, foundKontum);
            await _kontumRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchKontum(
            int id, JsonPatchDocument<KontumUpdateDto> patch)
        {
            var foundKontum = await _kontumRepository.GetKontumAsync(id);
            if (foundKontum is null)
                return NotFound();

            var kontumToPatch = _mapper.Map<KontumUpdateDto>(foundKontum);

            patch.ApplyTo(kontumToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(kontumToPatch))
                return BadRequest(ModelState);

            _mapper.Map(kontumToPatch, foundKontum);
            await _kontumRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKontum(int id)
        {
            var foundKontum = await _kontumRepository.GetKontumAsync(id);
            if (foundKontum is null)
                return NotFound();

            _kontumRepository.DeleteKonto(foundKontum);
            await _kontumRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
