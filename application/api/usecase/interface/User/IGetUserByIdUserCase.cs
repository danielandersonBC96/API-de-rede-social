namespace API_de_rede_social.application.api.usecase.@interface.User
{
    public interface IGetUserByIdUserCase
    {
        Task ExecuteAsync(Guid id);
    }
}