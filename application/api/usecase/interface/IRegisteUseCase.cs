using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface
{
    public interface IRegisterUserUseCase
    {
        Task<UserEntity> ExecuteAsync(string name, string email, string password);
    }
}
