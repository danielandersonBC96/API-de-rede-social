namespace API_de_rede_social.application.api.usecase.@interface
{
    public interface IGetPostByIdUseCase
    {
        Task<object> ExecuteAsync(Guid postId);
    }
}
