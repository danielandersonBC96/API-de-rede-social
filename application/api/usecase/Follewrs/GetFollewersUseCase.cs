using API_de_rede_social.application.api.@interface.Follewrs;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

public class GetFollowersUseCase : IGetFollowersUseCase
{
    private readonly IUserFollowRepository _repo;

    public GetFollowersUseCase(IUserFollowRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<UserEntity>> ExecuteAsync(Guid userId)
    {
        return await _repo.GetFollowersAsync(userId);
    }
}
