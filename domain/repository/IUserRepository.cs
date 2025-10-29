using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository
{
  
}public class IUserRepository
    {
        public interface IUseresRepository
        {
            Task<UserEntities?> GetByIdAsync(Guid userId);
            Task<IEnumerable<UserEntities>> GetAllAsync();
            Task<UserEntities> AddAsync(UserEntities user);
            Task<UserEntities> UpdateAsync(UserEntities user);
            Task<UserEntities> DeleteAsync(Guid userId);
            Task SaveChangesAsync();
        }
}
