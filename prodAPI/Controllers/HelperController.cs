using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;
using System.Text.Json;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class HelperController : Controller
    {
        //private readonly ILogger<HelperController> _logger;
        private readonly IHelperRepository _helperRepository;
        //private readonly IMapper _mapper;
        const int maxPageSize = 20;
        public HelperController(IHelperRepository HelperRepository, ILogger<HelperController> logger, IMapper mapper)
        {
            _helperRepository = HelperRepository ?? throw new ArgumentNullException(nameof(HelperRepository));
           // _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("ZleceniaPracownika/{id}")]
        public async Task<ActionResult<IEnumerable<ZleceniumDto>>> GetZleceniaByPracownik(
            int id)
        {
            var (zlecenia, paginationMetadata) = await _helperRepository
                .GetZleceniaByPracownikAsync(id);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));
            return Ok(zlecenia);
        }
       
    }
}
