using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository;
using API_de_rede_social.Domain.Repository;

namespace API_de_rede_social.application.api.usecase
{
    public class CreateCommentUseCase : ICreateCommentUseCase
    {

        private readonly ICreateCommentUseCase _commentRepository;
        private readonly IUserRepository userRepository;

        public CreateCommentUseCase (ICommentsRepository commentsRepository, IUserRepository userRepository)
        {
            _commentRepository = (ICreateCommentUseCase?)commentsRepository;
            this.userRepository = userRepository;
        }


        public CreateCommentUseCase(ICreateCommentUseCase commentRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            userRepository = userRepository;
        }

        public async Task ExecuteAsync(Guid userId, Guid postId, string content)
        {
            //Valida se o usuario existe 

            var user = await userRepository.GetAllAsync();

            var user = await userRepository.GetByIdAsync(userId);
            if(user==null)
            {       
                var comment = new CommentEntities
                {
                    PostId = postId,
                    UserId = userId,
                    Content = content,
                    CreatedAt = DateTime.UtcNow
                };

                //Persiste o comentário

                await _commentRepository.AddAsync(comment);
            }
        }
    }
}
 