using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialNetworkDBContext _context;

        public PostRepository(SocialNetworkDBContext context)
        {
            _context = context;
        }

        // Buscar post por ID
        public async Task<PostEntities?> GetByIdAsync(Guid postId)
        {
            return await _context.PostEntities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == postId);
        }

        // Buscar todos os posts
        public async Task<IEnumerable<PostEntities>> GetAllAsync()
        {
            return await _context.PostEntities
                .AsNoTracking()
                .ToListAsync();
        }

        // Criar post
        public async Task<PostEntities> AddAsync(PostEntities post)
        {
            _context.PostEntities.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        // Atualizar post
        public async Task<PostEntities> UpdateAsync(PostEntities post)
        {
            _context.PostEntities.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        // Excluir post
        public async Task DeleteAsync(Guid postId)
        {
            var entity = await _context.PostEntities.FirstOrDefaultAsync(x => x.Id == postId);

            if (entity is null)
                return;

            _context.PostEntities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // SaveChanges separado (caso queira usar Unit of Work)
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
