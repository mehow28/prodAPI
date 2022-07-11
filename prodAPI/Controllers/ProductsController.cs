﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProduktyRepository _produktyRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProduktyRepository productionRepository, ILogger<ProductsController> logger, IMapper mapper)
        {
            _produktyRepository = productionRepository ?? throw new ArgumentNullException(nameof(productionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProduktyDto>>> GetProdukty()
        {
            var products = await _produktyRepository.GetProduktyAsync();
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
            int id, ProduktyUpdateDto produkt)
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
            int id, JsonPatchDocument<ProduktyUpdateDto> patch)
        {
            var foundProdukt = await _produktyRepository.GetProduktyAsync(id);
            if (foundProdukt is null)
                return NotFound();
            
            var produktToPatch = _mapper.Map<ProduktyUpdateDto>(foundProdukt);

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
