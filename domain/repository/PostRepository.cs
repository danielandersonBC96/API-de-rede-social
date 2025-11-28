using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.domain.repository
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialNetworkDBContext _db;

        public PostRepository(SocialNetworkDBContext db)
        {
            _db = db;
        }

        // Buscar por ID
        public async Task<PostEntities?> GetByIdAsync(Guid postId)
        {
            return await _db.PostEntities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == postId);
        }

        // Buscar todos
        public async Task<IEnumerable<PostEntities>> GetAllAsync()
        {
            return await _db.PostEntities
                .AsNoTracking()
                .ToListAsync();
        }

        // Criar post
        public async Task<PostEntities> AddAsync(PostEntities post)
        {
            await _db.PostEntities.AddAsync(post);
            await _db.SaveChangesAsync();
            return post;
        }

        // Atualizar post
        public async Task<PostEntities> UpdateAsync(PostEntities post)
        {
            _db.PostEntities.Update(post);
            await _db.SaveChangesAsync();
            return post;
        }

        // Remover post
        public async Task DeleteAsync(Guid postId)
        {
            var existing = await _db.PostEntities
                .FirstOrDefaultAsync(x => x.Id == postId);

            if (existing is null)
                return; // silencioso ou jogar exceção — depende da regra

            _db.PostEntities.Remove(existing);
            await _db.SaveChangesAsync();
        }

        // SaveChanges separado (caso futuro de UnitOfWork)
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
