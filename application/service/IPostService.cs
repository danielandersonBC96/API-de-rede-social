using API_de_rede_social.domain.entities;
using API_de_rede_social.Domain.Entities;

namespace API_de_rede_social.Application.Service
{
    public interface IPostService
    {
        Task<IEnumerable<PostEntities>> GetAllAsync();
        Task<PostEntities?> GetByIdAsync(Guid postId);
        Task<PostEntities> CreateAsync(Guid userId, string content);
        Task<PostEntities> UpdateAsync(Guid postId, string content);
        Task DeleteAsync(Guid postId);
    }
}
