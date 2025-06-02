using InventoryService.Domain.Entities;
using InventoryService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepository _assetRepository;

        public AssetsController(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        // GET: api/assets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _assetRepository.GetAllAsync();
            return Ok(assets);
        }

        // GET: api/assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
                return NotFound();

            return Ok(asset);
        }

        //// POST: api/assets
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] Asset asset)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    await _assetRepository.AddAsync(asset);
        //    return CreatedAtAction(nameof(Get), new { id = asset.Id }, asset);
        //}

        //// PUT: api/assets/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] Asset asset)
        //{
        //    if (id != asset.Id)
        //        return BadRequest("ID mismatch");

        //    var existing = await _assetRepository.GetByIdAsync(id);
        //    if (existing == null)
        //        return NotFound();

        //    await _assetRepository.UpdateAsync(asset);
        //    return NoContent();
        //}

        //// DELETE: api/assets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var existing = await _assetRepository.GetByIdAsync(id);
        //    if (existing == null)
        //        return NotFound();

        //    await _assetRepository.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}
