using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository.repositories
{
    public interface ICommentRepository
    {
        Task<CommentEntities?> GetByIdAsync(Guid id);
        Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId);
        Task<CommentEntities> AddAsync(CommentEntities comment);
        Task<CommentEntities> UpdateAsync(CommentEntities comment);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
