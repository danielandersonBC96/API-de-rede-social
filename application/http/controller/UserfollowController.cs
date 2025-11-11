using API_de_rede_social.application.service;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserfollowController : ControllerBase
    {

        private readonly UserFollowService _userFollowService;


        public UserfollowController(UserFollowService userFollowService)
        {
            _userFollowService = userFollowService;
        }

        [HttpPost("follow")]

        public async Task<IActionResult> Follow([FromBody] FollowRequest request)
        {
            await _userFollowService.FollowAsync(request.followerId, request.followeeId);
            return Ok(new { message ="Agora voce segue este usuário"});

        }

        [HttpPost("Unfollow")]
        public async Task<IActionResult> GetFollewrs(Guid useId)
        {
            var followers = await _userFollowService.GetFollowersAsync(useId);
            return Ok(followers);

        }

        [HttpGet("{userId}/follwers")]

        public async Task<IActionResult> GetFollwers(Guid userId)
        {

            var follers = await _userFollowService.GetFollowersAsync(userId);
            return Ok(following);

        }

    }
   
    
}
