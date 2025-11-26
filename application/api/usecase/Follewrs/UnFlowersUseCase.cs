using API_de_rede_social.application.api.@interface.Follewrs;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.Follewrs
{
    public class UnfollowUserUseCase : IUnfollowUserUseCase
    {
        private readonly IUserFollowRepository _userFollowRepository;

        public UnfollowUserUseCase(IUserFollowRepository userFollowRepository)
        {
            _userFollowRepository = userFollowRepository;
        }

        public async Task ExecuteAsync(Guid followerId, Guid followeeId)
        {
            if (followerId == followeeId)
                throw new Exception("Um usuário não pode deixar de seguir a si mesmo.");

            var already = await _userFollowRepository.IsFollowingAsync(followerId, followeeId);

            if (!already)
                throw new Exception("O usuário não está seguindo esse perfil.");

            await _userFollowRepository.UnfollowAsync(followerId, followeeId);
        }
    }
}
