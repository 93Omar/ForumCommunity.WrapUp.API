using Microsoft.AspNetCore.Mvc;
using NillForum.WrapUp.API.Repositories;
using NillForum.WrapUp.API.Services;

namespace NillForum.WrapUp.API.Controllers
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
