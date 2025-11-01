namespace API_de_rede_social.application.api.usecase
{
    public interface ICreateCommentUseCase
    {
        Task Execute(Guid userId, Guid postId, string content)
    }
}
