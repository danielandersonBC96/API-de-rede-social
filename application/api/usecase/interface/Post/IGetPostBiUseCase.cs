namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface IGetUserByIdUserCase
    {
        Task<object> ExecuteAsync(Guid postId);
    }
}
