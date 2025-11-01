using API_de_rede_social.application.usecases;
using API_de_rede_social.application.usecases.posts;
using API_de_rede_social.domain.entities;
using API_de_rede_social.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_de_rede_social.application.api.usecase
{
    public class CreatePostUserCase : ICreatePostUseCase
    {
        public readonly IPostRepository postRepository;
        public readonly IUserRepository userRepository;
    
        public CreatePostUserCase(IPostRepository postRepository, IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;

        }

        public Task AddAsync(CommentEntities comment)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(Guid userId, Guid postId, string content)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync(Guid userId, string content)
        {
            throw new NotImplementedException();
        }

        public async Task ExecutyAsync(string username, string password)
        {

            //Valida se o usuario existe

            var name = await userRepository.GetAllAsync();
            if (name == null)
                {
                    Id = Guid.NewGuid();
                    Name = name;
                    Email = email;
                    CreatedAt = DateTime.UtcNow;

            }

            await postRepository.AddAsync(post);
        }




    }


  }