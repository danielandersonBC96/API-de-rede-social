using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface.Follewrs
{
    internal interface IGetFollowingUseCase
    {
        Task<IEnumerable<UserEntity>> ExecuteAsync(Guid userId);
    }
}