using API_de_rede_social.application.api.usecase.@interface.Follewrs;
using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    internal class UserFollowService : IUserFollowService
    {
        private readonly IFollowUserUseCase _follow;
        private readonly IUnfollowUserUseCase _unfollow;
        private readonly IGetFollowersUseCase _getFollowers;
        private readonly IGetFollowingUseCase _getFollowing;

        internal UserFollowService(
            IFollowUserUseCase follow,
            IUnfollowUserUseCase unfollow,
            IGetFollowersUseCase getFollowers,
            IGetFollowingUseCase getFollowing)
        {
            _follow = follow;
            _unfollow = unfollow;
            _getFollowers = getFollowers;
            _getFollowing = getFollowing;
        }

        Task IUserFollowService.FollowAsync(Guid followerId, Guid followeeId)
            => _follow.ExecuteAsync(followerId, followeeId);

        Task IUserFollowService.UnfollowAsync(Guid followerId, Guid followeeId)
            => _unfollow.ExecuteAsync(followerId, followeeId);

        Task<IEnumerable<UserEntity>> IUserFollowService.GetFollowersAsync(Guid userId)
            => _getFollowers.ExecuteAsync(userId);

        Task<IEnumerable<UserEntity>> IUserFollowService.GetFollowingAsync(Guid userId)
            => _getFollowing.ExecuteAsync(userId);
    }
}