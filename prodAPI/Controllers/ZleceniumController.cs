using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;
using System.Text.Json;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/Zlecenium")]
    public class ZleceniumController : Controller
    {
        private readonly ILogger<ZleceniumController> _logger;
        private readonly IZleceniumRepository _zleceniumRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public ZleceniumController(IZleceniumRepository productionRepository, ILogger<ZleceniumController> logger, IMapper mapper)
        {
            _zleceniumRepository = productionRepository ?? throw new ArgumentNullException(nameof(productionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZleceniumDto>>> GetZlecenium(
            DateTime? data, int? idProduktu,
            int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (zlecenia, paginationMetadata) = await _zleceniumRepository
                .GetZleceniumAsync(data, idProduktu, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata)); 
            return Ok(_mapper.Map<IEnumerable<ZleceniumDto>>(zlecenia));
        }
        [HttpGet("{id}", Name = "GetZlecenium")]
        public async Task<ActionResult<ZleceniumDto>> GetZlecenium(int id)
        { 
            var foundProduct = await _zleceniumRepository.GetZleceniumAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<ZleceniumDto>> CreateZlecenium(ZleceniumCreationDto Zlecenium)
        {
            var newZlecenium = _mapper.Map<ZleceniumDto>(Zlecenium);
            await _zleceniumRepository.AddZleceniumAsync(newZlecenium);
            await _zleceniumRepository.SaveChangesAsync();

            return CreatedAtRoute("GetZlecenium",
                new
                {
                    id = newZlecenium.IdZlecenia
                },newZlecenium); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, ZleceniumUpdateDto Zlecenium)
        {
            var foundZlecenium = await _zleceniumRepository.GetZleceniumAsync(id);
            if (foundZlecenium is null)
                return NotFound();
            
            _mapper.Map(Zlecenium, foundZlecenium);
            await _zleceniumRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<ZleceniumUpdateDto> patch)
        {
            var foundZlecenium = await _zleceniumRepository.GetZleceniumAsync(id);
            if (foundZlecenium is null)
                return NotFound();
            
            var ZleceniumToPatch = _mapper.Map<ZleceniumUpdateDto>(foundZlecenium);

            patch.ApplyTo(ZleceniumToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(ZleceniumToPatch))
                return BadRequest(ModelState);

            _mapper.Map(ZleceniumToPatch, foundZlecenium);
            await _zleceniumRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundZlecenium = await _zleceniumRepository.GetZleceniumAsync(id);
            if (foundZlecenium is null)
                return NotFound();

            _zleceniumRepository.DeleteZlecenium(foundZlecenium);
            await _zleceniumRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
