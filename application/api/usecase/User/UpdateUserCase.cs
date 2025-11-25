using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.User
{
    public class UpdateUserUserCase
    {
        private readonly IUserRepository _repository;
        

        public UpdateUserUserCase(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity> ExecuteAsync(Guid id, string name , string email)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new Exception("Usuário não encontrado ");

            user.Name = name;
            user.Email = email;

            return await _repository.UpdateAsync(user);
        }
        

        }
    
}
