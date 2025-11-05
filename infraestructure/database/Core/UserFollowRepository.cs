using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class UserFollowRepository : IUserFollowRepository
    {
        private readonly SocialNetworkDBContext _dbContext;

        public UserFollowRepository(SocialNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task FollowAsync(Guid followerId, Guid followeeId)
        {
            var relation = new UserFollower { FollowerId = followerId, UserId = followeeId };
            await _dbContext.UserFollowers.AddAsync(relation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UnfollowAsync(Guid followerId, Guid followeeId)
        {
            var relation = await _dbContext.UserFollowers
                .FirstOrDefaultAsync(uf => uf.FollowerId == followerId && uf.UserId == followeeId);

            if (relation != null)
            {
                _dbContext.UserFollowers.Remove(relation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsFollowingAsync(Guid followerId, Guid followeeId)
        {
            return await _dbContext.UserFollowers
                
                .AnyAsync(uf => uf.FollowerId == followerId && uf.UserId == followeeId);
        }

        public async Task<IEnumerable<UserEntities>> GetFollowersAsync(Guid userId)
        {
            return await _dbContext.UserFollowers
                
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.Follower)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserEntities>> GetFollowingAsync(Guid followerId)
        {
            return await _dbContext.UserFollowers
                .Where(uf => uf.FollowerId == followerId)
                .Select(uf => uf.User)
                .ToListAsync();
        }
    }
}
