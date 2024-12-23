using ForumCommunity.WrapUp.API.Models;
using ForumCommunity.WrapUp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumCommunity.WrapUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly TokenVerifyService _tokenVerifyService;

        public TokenController(TokenVerifyService tokenVerifyService)
        {
            _tokenVerifyService = tokenVerifyService;
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> VerifyToken(VerifyTokenRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            ArgumentNullException.ThrowIfNull(request.Token, nameof(request.Token));
            ArgumentNullException.ThrowIfNull(request.UserId, nameof(request.UserId));

            bool tokenIsValid = await _tokenVerifyService.VerifyToken(request.UserId, request.Token);
            return Ok(tokenIsValid);
        }
    }
}
