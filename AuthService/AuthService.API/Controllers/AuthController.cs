using AuthService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthCheckService _authCheckService;

        public AuthController(IAuthCheckService authCheckService)
        {
            _authCheckService = authCheckService;
        }

        [HttpGet("{userId}/{assetId}")]
        public async Task<IActionResult> CheckEligibility(int userId, int assetId)
        {
            var result = await _authCheckService.IsEligibleAsync(userId, assetId);
            return Ok(result);
        }
    }

}
