using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class CommentRepository : ICommentRepository
    {
        private readonly SocialNetworkDBContext _context;

        public CommentRepository(SocialNetworkDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CommentEntities comment)
        {
            await _context.CommentEntities.AddAsync(comment);
        }

        public async Task<CommentEntities?> GetByIdAsync(Guid id)
        {
            return await _context.CommentEntities
                .Include(c => c.User)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId)
        {
            return await _context.CommentEntities
                .Include(c => c.User)
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task UpdateAsync(CommentEntities comment)
        {
            _context.CommentEntities.Update(comment);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await GetByIdAsync(id);
            if (existing != null)
            {
                _context.CommentEntities.Remove(existing);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
