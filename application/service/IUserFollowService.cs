using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    public interface IUserFollowService
    {
        Task FollowAsync(Guid followerId, Guid followeeId);
        Task UnfollowAsync(Guid followerId, Guid followeeId);
        Task<IEnumerable<UserEntities>> GetFollowersAsync(Guid userId);
        Task<IEnumerable<UserEntities>> GetFollowingAsync(Guid userId);
    }
}
