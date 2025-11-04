using API_de_rede_social.domain.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_de_rede_social.domain.repository
{
    public interface IUserFollowRepository
    {
        Task FollowAsync(Guid followerId, Guid followeeId);
        Task UnfollowAsync(Guid followerId, Guid followeeId);
        Task<bool> IsFollowingAsync(Guid followerId, Guid followeeId);

        Task<IEnumerable<UserEntities>> GetFollowersAsync(Guid userId);
        Task<IEnumerable<UserEntities>> GetFollowingAsync(Guid followerId);
    }
}
