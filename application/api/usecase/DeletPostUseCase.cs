using API_de_rede_social.Domain.Repository;

namespace API_de_rede_social.application.api.usecase
{
    public class DeletPostUseCase : IDeletePostUseCase

      {
        private readonly IPostRepository _postRepository;
        public DeletPostUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task ExecuteAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            if (post == null)
                throw new Exception("Post não encontrado.");
            await _postRepository.DeleteAsync(postId);
        }
    }
}
