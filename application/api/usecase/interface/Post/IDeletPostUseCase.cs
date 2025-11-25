namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface IDeletPostUseCase
    {
        Task ExecuteAsync(Guid postId);
    }
}