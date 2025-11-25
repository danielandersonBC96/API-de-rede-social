using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.Coment
{
    public class UpdateCommentUseCase : IUpdateCommentUseCase
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentUseCase(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task ExecuteAsync(Guid commentId, string newContent)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment is null)
                throw new InvalidOperationException("Comentário não encontrado.");

            comment.Content = newContent;
            comment.UpdatedAt = DateTime.UtcNow;

            await _commentRepository.UpdateAsync(comment);
        }
    }
}

