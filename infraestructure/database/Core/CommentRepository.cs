using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using Microsoft.EntityFrameworkCore;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class CommentRepository: ICommentsRepository
    {
        public readonly SocialNetworkDBContext _context;

        public CommentRepository(SocialNetworkDBContext context)
        {
            _context = context;
        }

        public Task AddAsync( CommentEntities coment)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentEntities?> GetByIdAsync(Guid postId)
        {
            return await _context.CommentEntities.Include(e => e.User).Where(e => e.PostId == postId).ToListAsync();

        }


        public async Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId)
        {
            return await _context.CommentEntities
                .Include(c => c.User)
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
