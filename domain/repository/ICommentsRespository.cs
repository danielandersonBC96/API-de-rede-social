using API_de_rede_social.domain.entities;

namespace API_de_rede_social.domain.repository
{
    public class ICommentsRespository
    {
        public interface IComentesRepository
        {
            Task <CommentEntities? > GetByIdAsync (int id);

            Task<IEnumerable<CommentEntities>> GetByIdsAsync(Guid postId);

            Task AddAsync(CommentEntities coment);

            Task SaveChangESAsync(CommentEntities coment);

            Task DeleteAsync(int id);

            
        }
    }
}
