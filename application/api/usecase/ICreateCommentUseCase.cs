using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.usecases
{
    public interface ICreateCommentUseCase
    {
        Task AddAsync(CommentEntities comment);
        Task ExecuteAsync(Guid userId, Guid postId, string content);
    }
}
