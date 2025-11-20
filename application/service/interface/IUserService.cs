using API_de_rede_social.domain.entities;

namespace API_de_rede_social.Application.Service
{
    public interface IUserService
    {
        Task<UserEntity?> GetByIdAsync(Guid userId);
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> CreateAsync(string name, string email);
    }
}
