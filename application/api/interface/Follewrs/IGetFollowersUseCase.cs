using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.@interface.Follewrs
{
    public interface IGetFollowersUseCase
    {
        Task<IEnumerable<UserEntity>> ExecuteAsync(Guid userId);
    }
}