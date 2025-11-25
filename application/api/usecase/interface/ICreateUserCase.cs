namespace API_de_rede_social.application.api.usecase.@interface
{
    public interface ICreateUserUseCase
    {
        Task ExecuteAsync(string name, string email);
    }
}
