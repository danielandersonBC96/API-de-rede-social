namespace API_de_rede_social.application.api.@interface.User
{
    public interface IGetUserByIdUserCase
    {
        Task ExecuteAsync(Guid id);

        Task ExecuteAsync ( string user);
      
    }
}