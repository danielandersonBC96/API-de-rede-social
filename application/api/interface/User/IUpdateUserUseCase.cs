using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.@interface.User
{
   
        public interface IUpdateUserUseCase
        {
            Task<UserEntity> ExecuteAsync(Guid id, string name, string email);
        }

    
}