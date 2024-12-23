using ForumCommunity.WrapUp.API.Models;
using ForumCommunity.WrapUp.API.Models.Database;
using ForumCommunity.WrapUp.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ForumCommunity.WrapUp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            ArgumentNullException.ThrowIfNull(request.Nickname, nameof(request.Nickname));

            User user = new()
            {
                Nickname = request.Nickname,
                Id = request.UserId,
                ForumId = request.ForumId
            };
            int userId = await _userRepository.CreateAsync(user);
            return Ok(userId);
        }
    }
}
