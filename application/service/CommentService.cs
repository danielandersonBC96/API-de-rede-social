
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository;


namespace API_de_rede_social.Application.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentsRespository _commentRepository;

        public CommentService(ICommentsRespository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId)
        {
            return await _commentRepository.GetByPostIdAsync(postId);
        }

        public async Task<CommentEntities> CreateAsync(Guid userId, Guid postId, string content)
        {
            var comment = new CommentEntities
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                PostId = postId,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            return await _commentRepository.AddAsync(comment);
        }

        public async Task DeleteAsync(Guid commentId)
        {
            await _commentRepository.DeleteAsync(commentId);
        }
    }
}
