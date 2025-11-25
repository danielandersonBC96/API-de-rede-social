using API_de_rede_social.domain.repository.repositories;


namespace API_de_rede_social.application.api.usecase.Coment
{
    public class DeleteCommentUseCase : IDeleteCommentUseCase
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentUseCase(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task ExecuteAsync(Guid commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            if (comment == null)
                throw new Exception("Comentário não encontrado.");

            await _commentRepository.DeleteAsync(commentId);
        }
    }
}
