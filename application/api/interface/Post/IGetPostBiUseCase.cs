using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.User
{
    public interface IGetUserByIdUserCase
    {
        Task<UserEntity?> ExecuteAsync(Guid id);
    }
}
