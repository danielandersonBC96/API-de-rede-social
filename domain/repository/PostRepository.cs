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

        public async Task<PostEntities> GetByIdAsync(Guid postId)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _db.PostEntities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == postId);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<IEnumerable<PostEntities>> GetAllAsync()
        {
            return await _db.PostEntities.AsNoTracking().ToListAsync();
        }

        public async Task<PostEntities> AddAsync(PostEntities post)
        {
            await _db.PostEntities.AddAsync(post);
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task<PostEntities> UpdateAsync(PostEntities post)
        {
            _db.PostEntities.Update(post);
            await _db.SaveChangesAsync();
            return post;
        }

        public async Task DeleteAsync(Guid postId )
        {
            var existing = await _db.PostEntities.FirstOrDefaultAsync(x => x.Id == postId);

            if (existing is null)
                return;

            _db.PostEntities.Remove(existing);
            await _db.SaveChangesAsync();

        }


        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }


    }
    
}

