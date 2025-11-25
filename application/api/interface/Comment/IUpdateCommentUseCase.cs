namespace API_de_rede_social.application.api.@interface.Comment
{
    public interface IUpdateCommentUseCase
    {
        Task ExecuteAsync(Guid commentId, string newContent);
    }
}
