using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.domain.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkDBContext _db;

        public UserRepository(SocialNetworkDBContext db)
        {
            _db = db;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid userId)
        {
            return await _db.UserEntities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _db.UserEntities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserEntity> AddAsync(UserEntity user)
        {
            await _db.UserEntities.AddAsync(user);
            await _db.SaveChangesAsync(); 
            return user;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            _db.UserEntities.Update(user);
            await _db.SaveChangesAsync(); 
            return user;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var existing = await _db.UserEntities
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (existing is null)
                return;

            _db.UserEntities.Remove(existing);
            await _db.SaveChangesAsync(); 
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
