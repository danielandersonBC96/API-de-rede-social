using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository;
using API_de_rede_social.Domain.Repository;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialNetworkDBContext _context;
    

    public PostRepository(SocialNetworkDBContext context)
        {
            _context = context;
        }
        public async Task<PostEntities?> GetByIdAsync(Guid postId)
        {
            return await _context.PostEntities.FindAsync(postId);
        }
        public async Task<IEnumerable<PostEntities>> GetAllasync()
        {
            return await _context.PostEntities.ToListAsync();
        }

        public async Task<PostEntities> AddAsync(PostEntities post)
        {
            _context.PostEntities.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<PostEntities> UpdateAsync(PostEntities post)
        {
            _context.PostEntities.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }   

    }
    }
