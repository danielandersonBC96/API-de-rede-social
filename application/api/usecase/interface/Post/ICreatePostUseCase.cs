using System;
using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface ICreatePostUseCase
    {
        Task<Guid> ExecuteAsync(Guid userId, string content, string? imageUrl = null);
    }
}
