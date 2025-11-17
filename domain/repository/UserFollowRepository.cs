using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.domain.repository
{
    public class UserFollowRepository : IUserFollowRepository
    {
        private readonly SocialNetworkDBContext _db;

        public UserFollowRepository(SocialNetworkDBContext db)
        {
            _db = db;
        }

        // SEGUIR
        public async Task FollowAsync(Guid followerId, Guid followeeId)
        {
            // evita follow duplicado
            var alreadyFollowing = await _db.UserFollowers
                .AnyAsync(x => x.FollowerId == followerId && x.UserId == followeeId);

            if (alreadyFollowing)
                return;

            var follow = new UserFollowerEntities
            {
                UserId = followeeId,      // o dono do perfil
                FollowerId = followerId   // quem está seguindo
            };

            await _db.UserFollowers.AddAsync(follow);
            await _db.SaveChangesAsync();
        }

        // DEIXAR DE SEGUIR
        public async Task UnfollowAsync(Guid followerId, Guid followeeId)
        {
            var existing = await _db.UserFollowers
                .FirstOrDefaultAsync(x => x.FollowerId == followerId && x.UserId == followeeId);

            if (existing == null)
                return;

            _db.UserFollowers.Remove(existing);
            await _db.SaveChangesAsync();
        }

        // VERIFICA SE ESTÁ SEGUINDO
        public async Task<bool> IsFollowingAsync(Guid followerId, Guid followeeId)
        {
            return await _db.UserFollowers
                .AnyAsync(x => x.FollowerId == followerId && x.UserId == followeeId);
        }

        // LISTAR QUEM SEGUE O USUÁRIO
        public async Task<IEnumerable<UserEntity>> GetFollowersAsync(Guid userId)
        {
            return await _db.UserFollowers
                .Where(x => x.UserId == userId)
                .Select(x => x.Follower)
                .AsNoTracking()
                .ToListAsync();
        }

        // LISTAR QUEM O USUÁRIO ESTÁ SEGUINDO
        public async Task<IEnumerable<UserEntity>> GetFollowingAsync(Guid userId)
        {
            return await _db.UserFollowers
                .Where(x => x.FollowerId == userId)
                .Select(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
