using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.usecases.posts
{
    public class CreatePostUseCase : ICreatePostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CreatePostUseCase(
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(Guid userId, string content, string? imageUrl = null)
        {
            // Verifica se o usuário existe
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            // Cria o post
            var post = new PostEntities
            {
                UserId = userId,
                Content = content,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            // Salva no repositório
            await _postRepository.AddAsync(post);
        }
    }
}
