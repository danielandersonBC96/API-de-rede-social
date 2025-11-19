using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.usecases.userfollow
{
    public interface IGetFollowersUseCase
    {
        Task<IEnumerable<UserEntity>> ExecuteAsync(Guid userId);
    }
}
