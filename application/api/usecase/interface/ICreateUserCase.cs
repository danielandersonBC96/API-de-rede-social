using API_de_rede_social.domain.entities;

public interface ICreateUserUseCase
{
    Task<UserEntity> ExecuteAsync(string name, string email);
}
