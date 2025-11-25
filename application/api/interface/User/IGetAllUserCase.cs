using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.@interface.User
{
    public interface IGetAllUserCase
    {
        Task<IEnumerable<UserEntity>> ExecuteAsync();
    }

}