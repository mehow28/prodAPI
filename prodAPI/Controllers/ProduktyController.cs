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
    [Route("api/produkty")]
    public class ProduktyController : Controller
    {
        private readonly ILogger<ProduktyController> _logger;
        private readonly IProduktyRepository _produktyRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public ProduktyController(IProduktyRepository productionRepository, ILogger<ProduktyController> logger, IMapper mapper)
        {
            _produktyRepository = productionRepository ?? throw new ArgumentNullException(nameof(productionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktyDto>>> GetProdukty(
            string? nazwa, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;

            var (products,paginationMetadata) = await _produktyRepository
                .GetProduktyAsync(nazwa, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<ProduktyDto>>(products));
        }
        [HttpGet("{id}", Name = "GetProdukt")]
        public async Task<ActionResult<ProduktyDto>> GetProdukty(int id)
        { 
            var foundProduct = await _produktyRepository.GetProduktyAsync(id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }
        [HttpPost]
        public async Task<ActionResult<ProduktyDto>> CreateProdukty(ProduktyCreationDto produkt)
        {
            var newProdukt = _mapper.Map<ProduktyDto>(produkt);
            await _produktyRepository.AddProduktAsync(newProdukt);
            await _produktyRepository.SaveChangesAsync();

            return CreatedAtRoute("GetProdukt",
                new
                {
                    id = newProdukt.IdProduktu
                },newProdukt); ;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>  UpdateProduct(
            int id, ProduktyDlaEtapuUpdateDto produkt)
        {
            var foundProdukt = await _produktyRepository.GetProduktyAsync(id);
            if (foundProdukt is null)
                return NotFound();
            
            _mapper.Map(produkt, foundProdukt);
            await _produktyRepository.SaveChangesAsync();
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchProduct(
            int id, JsonPatchDocument<ProduktyDlaEtapuUpdateDto> patch)
        {
            var foundProdukt = await _produktyRepository.GetProduktyAsync(id);
            if (foundProdukt is null)
                return NotFound();
            
            var produktToPatch = _mapper.Map<ProduktyDlaEtapuUpdateDto>(foundProdukt);

            patch.ApplyTo(produktToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(produktToPatch))
                return BadRequest(ModelState);

            _mapper.Map(produktToPatch, foundProdukt);
            await _produktyRepository.SaveChangesAsync();

            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var foundProdukt = await _produktyRepository.GetProduktyAsync(id);
            if (foundProdukt is null)
                return NotFound();

            _produktyRepository.DeleteProdukt(foundProdukt);
            await _produktyRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
