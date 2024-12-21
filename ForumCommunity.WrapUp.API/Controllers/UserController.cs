using ForumCommunity.WrapUp.API.Repositories;
using ForumCommunity.WrapUp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumCommunity.WrapUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly TokenVerifyService _tokenVerifyService;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, TokenVerifyService tokenVerifyService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tokenVerifyService = tokenVerifyService;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyToken(string userId, string token)
        {
            bool tokenIsValid = await _tokenVerifyService.VerifyToken(userId, token);
            return Ok(tokenIsValid);
        }
    }
}
