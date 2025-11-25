using API_de_rede_social.application.api.@interface.Post;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.post
{
    public class CreatePostUseCase : ICreatePostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CreatePostUseCase(
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _postRepository = postRepository
                ?? throw new ArgumentNullException(nameof(postRepository));
            _userRepository = userRepository
                ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Guid> ExecuteAsync(Guid userId, string content, string? imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("O conteúdo do post não pode ser vazio.", nameof(content));

            // Verifica se o usuário existe
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
                throw new KeyNotFoundException("Usuário não encontrado.");

            var post = new PostEntities { UserId = userId, Content = content.Trim(), ImageUrl = imageUrl, CreatedAt = DateTime.UtcNow, };

            await _postRepository.AddAsync(post);

            return post.Id; // se a entidade tiver Id gerado
        }

      
    }
}
