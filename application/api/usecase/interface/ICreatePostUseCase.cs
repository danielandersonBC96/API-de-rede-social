using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.usecases.posts
{
    public interface ICreatePostUseCase
    {
        Task ExecuteAsync(Guid userId, string content, string? imageUrl = null);
    }
}
