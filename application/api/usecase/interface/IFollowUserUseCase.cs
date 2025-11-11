namespace API_de_rede_social.application.api.usecase.@interface
{
    internal interface IFollowUserUseCase
    {
        Task ExecuteAsync(Guid followerId, Guid followeeId);
    }
}