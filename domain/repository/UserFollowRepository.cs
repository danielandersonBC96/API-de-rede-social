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

        //Seguir
        public async Task FollowAsync(Guid followerId, Guid followeeId)
        {
            // evita follow duplicado
            var alreadyFollow = await _db.UserFollowers
                .AnyAsync(x => x.FollowerId == followeeId && x.UserId == followeeId);

            if (alreadyFollow)
                return;

            var follow = new UserFollowerEntities
            {
                UserId = followerId,
                FollowerId= followeeId
            };

            await _db.UserFollowers.AddAsync(follow);
            await _db.SaveChangesAsync();
        }

        //deicar de seguir

        public async Task UnFollowersAsync(Guid followerId, Guid followeeId)
        {
            var existin = await _db.UserFollowers.FirstOrDefaultAsync(x => x.FollowerId == followerId && x.UserId == followerId);

            if (existin == null)
                return;

            _db.UserFollowers.Remove(existin);
            await _db.SaveChangesAsync();

        }

        //Verifica se segue 
        public async Task<bool> IsFollowingAsync(Guid follewerId, Guid folleweeId)
        {

            return await _db.UserFollowers
                .AnyAsync(X => X.FollowerId 
                == follewerId && X.UserId 
                == folleweeId);

        }


        //Lista quem segue o usuário 

        public async Task<IAsyncEnumerable<UserEntity>> GetFollerAsync(Guid userId)
        {
            return (IAsyncEnumerable<UserEntity>)await _db.UserFollowers
               .Where(x => x.UserId == userId)
               .Select(x => x.Follower)
               .AsNoTracking()
               .ToListAsync();
        }

        //lista quek esta seguindo o usuario 
        public async Task<IEnumerable<UserEntity>>GetFollowAsync(Guid userId)
        {

            return await _db.UserFollowers
                .Where(x => x.FollowerId == userId)
                .Select(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
