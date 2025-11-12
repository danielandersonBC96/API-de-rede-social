
namespace API_de_rede_social.application.api.usecase
{
    public interface IDeletPostUseCase
    {
        Task ExecuteAsync(Guid postId);
    }
}