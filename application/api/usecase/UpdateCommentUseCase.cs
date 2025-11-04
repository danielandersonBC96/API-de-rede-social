using API_de_rede_social.domain.repository;

namespace API_de_rede_social.application.usecases.comments
{
    public class UpdateCommentUseCase : IUpdateCommentUseCase
    {
        private readonly ICommentsRepository _commentRepository;

        public UpdateCommentUseCase(ICommentsRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task ExecuteAsync(Guid commentId, string newContent)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null)
                throw new Exception("Comentário não encontrado.");

            comment.Content = newContent;

            await _commentRepository.UpdateAsync(comment); // precisa existir UpdateAsync no repository
        }
    }
}
