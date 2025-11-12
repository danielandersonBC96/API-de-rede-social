using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface
{
    public interface IGetFollowersUseCase
    {
        Task<IEnumerable<UserEntities>> ExecuteAsync(Guid userId);
    }
}