using API_de_rede_social.domain.entities;

namespace API_de_rede_social.Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserEntities?> GetByIdAsync(Guid userId);
        Task<IEnumerable<UserEntities>> GetAllAsync();
        Task<UserEntities> AddAsync(UserEntities user);
        Task<UserEntities> UpdateAsync(UserEntities user);
        Task DeleteAsync(Guid userId);
        Task SaveChangesAsync();
        Task<UserEntities> AddAsync(object user);
    }
}

