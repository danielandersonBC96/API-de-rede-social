namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface IUnfollowUserUseCase
    {
        Task ExecuteAsync(Guid followerId, Guid followeeId);
    }
}
