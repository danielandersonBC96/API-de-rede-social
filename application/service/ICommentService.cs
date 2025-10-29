using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    public class ICommentService
    {

        public interface IICommentService
        {
            Task<IEnumerable<CommentEntities>> GetCommentsByPostIdAsync(Guid postId);
            Task<CommentEntities?> GetCommentByIdAsync(int commentId);

        }
    }
}
