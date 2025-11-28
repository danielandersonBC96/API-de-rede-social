using API_de_rede_social.domain.entities;

public interface IUpdateUserUseCase
{
    Task<UserEntity> ExecuteAsync(Guid id, string name, string email);
}
