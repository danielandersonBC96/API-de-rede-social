using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.api.@interface.Post
{
    public interface IGetAllPostUseCase
    {
        Task<IEnumerable<PostEntities>> ExecuteAsync();
    }
}