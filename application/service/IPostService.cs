using API_de_rede_social.domain.entities;

namespace API_de_rede_social.application.service
{
    public  class IPostService
    {
        public interface IIPostService
        {
            Task<IEnumerable<PostEntities>> GetAllPostAsync();
            Task<PostEntities?>GetPostByIdAsync(Guid postId);

            Task<PostEntities> CreatePostAsync(Guid userId, string content);

            Task<PostEntities> DeletePostAsync(Guid postId);


        }
    }
}
