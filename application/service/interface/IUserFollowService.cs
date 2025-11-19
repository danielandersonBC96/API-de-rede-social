using API_de_rede_social.domain.entities;

public interface IUserFollowService
{
    Task FollowAsync(Guid followerId, Guid followeeId);
    Task UnfollowAsync(Guid followerId, Guid followeeId);

    Task<IEnumerable<UserEntity>> GetFollowersAsync(Guid userId);
    Task<IEnumerable<UserEntity>> GetFollowingAsync(Guid userId);
}
