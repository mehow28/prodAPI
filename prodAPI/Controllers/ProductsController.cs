using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using productionAPI.Models;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProduktyDto>> GetProducts()
        {
            var products = new List<ProduktyDto>(); ;
            return Ok(ProduktyDataStore.Current.Produkty);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<ProduktyDto> GetProduct(int id)
        {
            var foundProduct = ProduktyDataStore.Current.Produkty
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundProduct == null)
            {
                _logger.LogInformation($"Produkt o id {id} nie został znaleziony.");
                return NotFound();
            }
            return Ok(foundProduct);
        }
        [HttpPost]
        public ActionResult<ProduktyDto> CreateProduct(ProduktyCreationDto ProduktDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var maxIdProduktu = ProduktyDataStore.Current.Produkty
                .Max(c=>c.IdProduktu);

            var newProduct = new ProduktyDto()
            {
                IdProduktu = ++maxIdProduktu,
                Nazwa = ProduktDto.Nazwa
            };
            ProduktyDataStore.Current.Produkty.Add(newProduct);
            return CreatedAtRoute("GetProduct",
                new
                {
                    id = newProduct.IdProduktu
                },newProduct); ;
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(
            int id, ProduktyUpdateDto produkt)
        {
            var foundProduct = ProduktyDataStore.Current.Produkty
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundProduct == null)
                return NotFound();
            foundProduct.Nazwa = produkt.Nazwa;

            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PatchProduct(
            int id, JsonPatchDocument<ProduktyUpdateDto> patch)
        {
            var foundProduct = ProduktyDataStore.Current.Produkty
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundProduct == null)
                return NotFound();

            var productToPatch =
                new ProduktyUpdateDto()
                {
                    Nazwa = foundProduct.Nazwa
                };

            patch.ApplyTo(productToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(productToPatch))
                return BadRequest(ModelState);

            foundProduct.Nazwa = productToPatch.Nazwa;

            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var foundProduct = ProduktyDataStore.Current.Produkty
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundProduct == null)
                return NotFound();

            ProduktyDataStore.Current.Produkty.Remove(foundProduct);
            return NoContent();
        }
    }
}
