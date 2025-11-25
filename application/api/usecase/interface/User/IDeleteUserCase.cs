namespace API_de_rede_social.application.api.usecase.@interface.User
{
    public interface IDeleteUserCase
    {
        Task ExecuteAsync(Guid id);
    }

}