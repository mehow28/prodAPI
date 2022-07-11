using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;
using prodAPI.Services;

namespace prodAPI.Controllers
{
    [ApiController]
    [Route("api/etapies")]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<EtapyDto>> GetEtap(int id)
        {
            var foundEtap = await _etapyRepository.GetEtapyAsync(id);
            if (foundEtap == null)
                return NotFound();
            return Ok(foundEtap);
        }

    }
}
