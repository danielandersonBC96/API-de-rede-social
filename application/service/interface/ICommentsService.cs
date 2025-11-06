using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentEntities>> GetCommentsByPostIdAsync(Guid postId);
        Task<CommentEntities?> GetCommentByIdAsync(int id);
        Task<CommentEntities> CreateCommentAsync(Guid postId, Guid userId, string content);
        Task<CommentEntities> UpdateCommentAsync(int id, string newContent);
        Task DeleteCommentAsync(int id);
    }
}

