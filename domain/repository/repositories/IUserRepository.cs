using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository.repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(Guid userId);
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> AddAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(UserEntity user);
        Task DeleteAsync(Guid userId);
        Task SaveChangesAsync();
        
    }
}

