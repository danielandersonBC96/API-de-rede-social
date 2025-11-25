namespace API_de_rede_social.application.api.@interface.Follewrs
{
    internal interface IFollowUserUseCase
    {
        Task ExecuteAsync(Guid followerId, Guid followeeId);
    }
}