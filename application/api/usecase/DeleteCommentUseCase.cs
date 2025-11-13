using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.usecases.comments
{
    public class DeleteCommentUseCase : IDeleteCommentUseCase
    {
        private readonly ICommentsRepository _commentRepository;

        public DeleteCommentUseCase(ICommentsRepository commentRepository)
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
