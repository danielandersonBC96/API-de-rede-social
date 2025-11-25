using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface IGetAllPostUseCase
    {
        Task<IEnumerable<PostEntities>> ExecuteAsync();
    }
}