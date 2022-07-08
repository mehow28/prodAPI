using Microsoft.AspNetCore.Mvc;
using productionAPI.Models;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProduktyDto>> GetProducts()
        {
            var products = new List<ProduktyDto>(); ;
            return Ok(ProduktyDataStore.Current.Produkty);
        }
        [HttpGet("{id}")]
        public ActionResult<ProduktyDto> GetProduct(int id)
        {
            var foundProduct = ProduktyDataStore.Current.Produkty
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundProduct == null)
                return NotFound();
            return Ok(foundProduct);
        }

    }
}
