using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.domain.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly SocialNetworkDBContext _db;

        public CommentRepository(SocialNetworkDBContext db)
        {
            _db = db;
        }

        // Buscar por ID
        public async Task<CommentEntities?> GetByIdAsync(Guid id)
        {
            return await _db.CommentEntities
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Buscar comentários de um post
        public async Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId)
        {
            return await _db.CommentEntities
                .Where(x => x.PostId == postId)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        // Criar comentário
        public async Task<CommentEntities> AddAsync(CommentEntities comment)
        {
            await _db.CommentEntities.AddAsync(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        // Atualizar comentário
        public async Task<CommentEntities> UpdateAsync(CommentEntities comment)
        {
            _db.CommentEntities.Update(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        // Deletar comentário
        public async Task DeleteAsync(Guid id)
        {
            var existing = await _db.CommentEntities.FirstOrDefaultAsync(c => c.Id == id);

            if (existing == null)
                return;

            _db.CommentEntities.Remove(existing);
            await _db.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
