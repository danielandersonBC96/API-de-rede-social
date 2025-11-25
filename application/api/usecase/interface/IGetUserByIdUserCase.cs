
namespace API_de_rede_social.application.http.controller
{
    public interface IGetUserById
    {
        Task ExecuteAsync(Guid id);
    }
}