using API_de_rede_social.application.dto;
using API_de_rede_social.application.dto.userfollow;
using API_de_rede_social.application.service;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFollowController : ControllerBase
    {
        private readonly IUserFollowService _userFollowService;

        public UserFollowController(IUserFollowService userFollowService)
        {
            _userFollowService = userFollowService;
        }

        // POST api/userfollow/follow
        [HttpPost("follow")]
        public async Task<IActionResult> Follow([FromBody] FollowRequest request)
        {
            await _userFollowService.FollowAsync(request.FollowerId, request.FolloweeId);
            return Ok(new { message = "Agora você segue este usuário." });
        }

        // POST api/userfollow/unfollow
        [HttpPost("unfollow")]
        public async Task<IActionResult> Unfollow([FromBody] UnFollowRequest request)
        {
            await _userFollowService.UnfollowAsync(request.FollowerId, request.FolloweeId);
            return Ok(new { message = "Você deixou de seguir este usuário." });
        }

        // GET api/userfollow/{userId}/followers
        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(Guid userId)
        {
            var followers = await _userFollowService.GetFollowersAsync(userId);
            return Ok(followers);
        }

        // GET api/userfollow/{userId}/following
        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(Guid userId)
        {
            var following = await _userFollowService.GetFollowingAsync(userId);
            return Ok(following);
        }
    }
}
