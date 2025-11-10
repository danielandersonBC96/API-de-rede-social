using API_de_rede_social.application.api.usecase;
using API_de_rede_social.application.usecases.userfollow;

namespace API_de_rede_social.application.service
{
	public class UserFollowService
	{
		private readonly IFollowUserUseCase _followUseCase;
		private readonly IUnfollowUserUseCase _unfollowUseCase;
		private readonly IGetFollowersUseCase _getFollowersUseCase;
		private readonly IGetFollowingUseCase _getFollowingUseCase;

		public UserFollowService(
			IFollowUserUseCase followUseCase,
			IUnfollowUserUseCase unfollowUseCase,
			IGetFollowersUseCase getFollowersUseCase,
			IGetFollowingUseCase getFollowingUseCase)
		{
			_followUseCase = followUseCase;
			_unfollowUseCase = unfollowUseCase;
			_getFollowersUseCase = getFollowersUseCase;
			_getFollowingUseCase = getFollowingUseCase;
		}

		public async Task FollowAsync(Guid followerId, Guid followeeId)
		{
			await _followUseCase.ExecuteAsync(followerId, followeeId);
		}

		public async Task UnfollowAsync(Guid followerId, Guid followeeId)
		{
			await _unfollowUseCase.ExecuteAsync(followerId, followeeId);
		}

		public async Task<IEnumerable<UserEntities>> GetFollowersAsync(Guid userId)
		{
			return await _getFollowersUseCase.ExecuteAsync(userId);
		}

		public async Task<IEnumerable<UserEntities>> GetFollowingAsync(Guid userId)
		{
			return await _getFollowingUseCase.ExecuteAsync(userId);
		}
	}
}
