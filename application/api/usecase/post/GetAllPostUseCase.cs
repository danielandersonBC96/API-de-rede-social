using API_de_rede_social.application.api.@interface.Post;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.post
{
    public class GetAllPostUseCase : IGetAllPostUseCase
    {
        private readonly IPostRepository _repository;

        public GetAllPostUseCase(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PostEntities>> ExecuteAsync( Guid id)
        {
            var posts = await _repository.GetAllAsync();
            return posts;
        }

     
    }
}
