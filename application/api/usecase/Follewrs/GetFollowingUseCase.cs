using API_de_rede_social.application.api.@interface.Follewrs;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.Follewrs
{
    public class GetFollowingUseCase : IGetFollowersUseCase
    {
        private readonly IUserFollowRepository _repo;

        public GetFollowingUseCase( IUserFollowRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<UserEntity>>ExecuteAsync(Guid userId)
        {
            return await _repo.GetFollowingAsync(userId);
        }
    }
}
