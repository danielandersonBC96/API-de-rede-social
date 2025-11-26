using API_de_rede_social.application.api.@interface.Follewrs;
using API_de_rede_social.domain.repository.repositories;

public class FollowUserUseCase : IFollowUserUseCase
{
    private readonly IUserFollowRepository _repo;

    public FollowUserUseCase(IUserFollowRepository repo)
    {
        _repo = repo;
    }

    public async Task ExecuteAsync(Guid followerId, Guid followeeId)
    {
        if (followerId == followeeId)
            throw new Exception("Um usuário não pode seguir ele mesmo.");

        bool already = await _repo.IsFollowingAsync(followerId, followeeId);
        if (already)
            throw new Exception("Você já segue este usuário.");

        await _repo.FollowAsync(followerId, followeeId);
    }
}
