using API_de_rede_social.application.api.usecase.@interface;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _repo;

        public CreateUserUseCase(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task ExecuteAsync(string name , string email) {
            {

                var user = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                };


                await _repo.AddAsync(user);

            } }
    }
}
