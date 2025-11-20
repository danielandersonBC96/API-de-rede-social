using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentEntities>> GetCommentsByPostIdAsync(Guid postId);
        Task<CommentEntities?> GetCommentByIdAsync(Guid id);
        Task<CommentEntities> CreateCommentAsync(Guid postId, Guid userId, string content);
        Task<CommentEntities> UpdateCommentAsync(Guid id, string newContent);
        Task DeleteCommentAsync(Guid id);
    }
}

