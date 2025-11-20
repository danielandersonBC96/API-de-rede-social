using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;


namespace API_de_rede_social.application.service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentEntities>> GetCommentsByPostIdAsync(Guid postId)
        {
            return await _commentRepository.GetByPostIdAsync(postId);
        }

        public async Task<CommentEntities?> GetCommentByIdAsync(Guid id)
        {
            return await _commentRepository.GetByIdAsync(id);
        }

        public async Task<CommentEntities> CreateCommentAsync(Guid postId, Guid userId, string content)
        {
            var comment = new CommentEntities
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            await _commentRepository.AddAsync(comment);
            return comment;
        }

        public async Task<CommentEntities> UpdateCommentAsync(Guid id, string newContent)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new Exception("Comentário não encontrado.");

            comment.Content = newContent;
            comment.UpdatedAt = DateTime.UtcNow;

            await _commentRepository.UpdateAsync(comment);

            return comment;
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            await _commentRepository.DeleteAsync(id);
        }
    }
}
