using API_de_rede_social.domain.entities;


namespace API_de_rede_social.Application.Service
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId);
        Task<CommentEntities> CreateAsync(Guid userId, Guid postId, string content);
        Task DeleteAsync(Guid commentId);
    }
}

