using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.User
{
    public class GetUserByIdUserCase : IGetUserByIdUserCase
    {
        private readonly IUserRepository _repo;

        public GetUserByIdUserCase(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserEntity?> ExecuteAsybc(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
