namespace API_de_rede_social.application.api.@interface.Post
{
    public interface IUnfollowUserUseCase
    {
        Task ExecuteAsync(Guid followerId, Guid followeeId);
    }
}
