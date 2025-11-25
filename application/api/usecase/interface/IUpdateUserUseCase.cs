using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface
{
    internal interface IUpdateUserUseCase
    {
        Task ExecuteAsyn(UserEntity model);
        Task ExecuteAsync(Guid id, string name, string email);
    }
}