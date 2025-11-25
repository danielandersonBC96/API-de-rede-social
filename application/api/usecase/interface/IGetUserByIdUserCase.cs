using API_de_rede_social.domain.entities;

public interface IGetUserByIdUserCase
{
    Task<UserEntity?> ExecuteAsync(Guid id);
}
