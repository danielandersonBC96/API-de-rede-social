using API_de_rede_social.domain.entities;


namespace API_de_rede_social.domain.repository.repositories
{
    public interface IPostRepository
    {
        Task<PostEntities?> GetByIdAsync(Guid postId);
        Task<IEnumerable<PostEntities>> GetAllAsync();
        Task<PostEntities> AddAsync(PostEntities post);
        Task<PostEntities> UpdateAsync(PostEntities post);
        Task DeleteAsync(Guid postId);
        Task SaveChangesAsync();
    }
}
