using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository
{
    public class IPostRepository
    {
        public interface IPosteRepository { 
        
        
            Task< PostEntities?> GetByIdAsync(Guid postId);
            Task<IEnumerable<PostEntities>> GetAllasync();

            Task<PostEntities> AddAsync(PostEntities post);

            Task<PostEntities> UpdateAsync(PostEntities post);

            Task<PostEntities> DeleteAsync(Guid postId);

            Task SaveChangesAsync();

           
        
        }
    }
}
