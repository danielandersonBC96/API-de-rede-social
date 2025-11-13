using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository.repositories
{
    public interface IUserRepository
    {
        Task<UserEntities?> GetByIdAsync(Guid userId);
        Task<IEnumerable<UserEntities>> GetAllAsync();
        Task<UserEntities> AddAsync(UserEntities user);
        Task<UserEntities> UpdateAsync(UserEntities user);
        Task DeleteAsync(Guid userId);
        Task SaveChangesAsync();
        
    }
}

