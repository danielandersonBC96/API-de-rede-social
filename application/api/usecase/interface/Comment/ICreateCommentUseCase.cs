using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface.Comment
{
    public interface ICreateCommentUseCase
    {
        Task AddAsync(CommentEntities comment);
        Task ExecuteAsync(Guid userId, Guid postId, string content);

    }
}
