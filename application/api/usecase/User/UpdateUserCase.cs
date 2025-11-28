using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.application.api.@interface.User;

namespace API_de_rede_social.application.api.usecase.User
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _repository;

        public UpdateUserUseCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity> ExecuteAsync(Guid id, string name, string email)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            user.Name = name;
            user.Email = email;

            return await _repository.UpdateAsync(user);
        }
    }
}
