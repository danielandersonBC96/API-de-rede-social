using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase
{
    public class GetPostByIdUseCase : IGetPostByIdUseCase
    {
        private readonly IPostRepository _repo;

        public GetPostByIdUseCase(IPostRepository repo)
        {
            _repo = repo;
        }

        public async Task<PostEntities?> ExecuteAsync(Guid postId)
        {
            return await _repo.GetByIdAsync(postId);
        }

       
    }

}
