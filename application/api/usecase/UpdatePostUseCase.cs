
using API_de_rede_social.Domain.Repository;



namespace API_de_rede_social.application.usecases.posts
{
    public class UpdatePostUseCase : IUpdatePostUseCase
    {
        private readonly IPostRepository _postRepository;

        public UpdatePostUseCase(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task ExecuteAsync(Guid postId, string newContent)
        {
            // Busca o post
            var post = await _postRepository.GetByIdAsync(postId);
            if (post == null)
                throw new Exception("Post não encontrado.");

            // Atualiza o conteúdo
            post.Content = newContent;

            // Salva no banco
            await _postRepository.UpdateAsync(post);
        }
    }
}
