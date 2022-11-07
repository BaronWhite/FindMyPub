using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Services;
using FindMyPubApi.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindMyPubApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubsController : ControllerBase
    {
        private readonly ILogger<PubsController> _logger;
        private readonly IPubService _service;

        public PubsController(ILogger<PubsController> logger, IPubService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Gets all the pubs
        /// </summary>
        /// <param name="searchString">Optional parameter to search by name</param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<PubDto>>> GetPubs(string? searchString = null)
        {
            var pubs = string.IsNullOrEmpty(searchString) ? await _service.Get() : await _service.GetWithName(searchString);
            return Ok(pubs.Select(pub => (PubDto)pub));
        }

        /// <summary>
        /// Gets all the pubs
        /// </summary>
        /// <param name="searchString">Optional parameter to search by name</param>
        /// <returns></returns>
        [HttpGet("summary")]
        public async Task<ActionResult<IReadOnlyList<PubSummaryDto>>> GetPubSummaries(string? searchString = null)
        {
            var pubs = string.IsNullOrEmpty(searchString) ? await _service.Get() : await _service.GetWithName(searchString);
            return Ok(pubs.Select(pub => (PubSummaryDto)pub));
        }

        /// <summary>
        /// Gets a pub by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{pubId}")]
        public async Task<ActionResult<PubDto>> GetPub(long pubId)
        {
            var pub = await _service.GetById(pubId);
            if (pub is null) return NotFound();
            return (PubDto)pub;
        }

        /// <summary>
        /// Creates a new Pub
        /// </summary>
        /// <param name="pub"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PubDto>> CreatePub(PubDto pub)
        {
            var created = await _service.Create((Pub)pub);
            return CreatedAtAction(nameof(CreatePub), new { id = created.Id }, (PubDto)created);
        }
    }
}
