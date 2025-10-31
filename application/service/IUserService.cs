using API_de_rede_social.domain.entities;

namespace API_de_rede_social.Application.Service
{
    public interface IUserService
    {
        Task<UserEntities?> GetByIdAsync(Guid userId);
        Task<IEnumerable<UserEntities>> GetAllAsync();
        Task<UserEntities> CreateAsync(string name, string email);
    }
}
