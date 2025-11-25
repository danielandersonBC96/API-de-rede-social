namespace API_de_rede_social.application.api.@interface.Post
{
    public interface IDeletPostUseCase
    {
        Task ExecuteAsync(Guid postId);
    }
}