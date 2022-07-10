using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/etapies")]
    public class EtapyController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<EtapyDto>> GetProducts()
        {
            var products = new List<EtapyDto>(); ;
            return Ok(EtapyDataStore.Current.Etapy);
        }
        [HttpGet("{id}")]
        public ActionResult<EtapyDto> GetProduct(int id)
        {
            var foundEtap = EtapyDataStore.Current.Etapy
                .FirstOrDefault(c => c.IdProduktu == id);
            if (foundEtap == null)
                return NotFound();
            return Ok(foundEtap);
        }

    }
}
