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
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Guid> ExecuteAsync(Guid userId, string content, string? imageUrl = null)
        {
            // validações básicas
            if (userId == Guid.Empty) throw new ArgumentException("userId inválido.", nameof(userId));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentException("Conteúdo do post é obrigatório.", nameof(content));

            // verifica se o usuário existe
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null) throw new InvalidOperationException("Usuário não encontrado.");

            var post = new PostEntities
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Content = content,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            await _postRepository.AddAsync(post);

            // retorna apenas o Id (conforme a interface)
            return post.Id;
        }
    }
}
