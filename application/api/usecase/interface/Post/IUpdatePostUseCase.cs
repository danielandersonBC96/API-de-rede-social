using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.api.usecase.@interface.Post
{
    public interface IUpdatePostUseCase
    {
        // Executa a atualização de um post
        Task ExecuteAsync(Guid postId, string newContent);
    }
}

