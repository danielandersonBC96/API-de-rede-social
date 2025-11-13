
using API_de_rede_social.Application.Service;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.Infraestructure.Persistence
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostEntities>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<PostEntities?> GetByIdAsync(Guid postId)
        {
            return await _postRepository.GetByIdAsync(postId);
        }

        public async Task<PostEntities> CreateAsync(Guid userId, string content)
        {
            var post = new PostEntities
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.UtcNow
            };

            return await _postRepository.AddAsync(post);
        }

        public async Task<PostEntities> UpdateAsync(Guid postId, string content)
        {
            var existing = await _postRepository.GetByIdAsync(postId);
            if (existing == null)
                throw new Exception("Post not found.");

            existing.Content = content;
            return await _postRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid postId)
        {
            await _postRepository.DeleteAsync(postId);
        }
    }
}
