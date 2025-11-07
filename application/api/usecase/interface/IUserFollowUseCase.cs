namespace API_de_rede_social.application.usecases.userfollow
{
    public interface IUnfollowUserUseCase
    {
        Task ExecuteAsync(Guid followerId, Guid followeeId);
    }
}
