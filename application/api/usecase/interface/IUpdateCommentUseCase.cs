using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.usecases.comments
{
    public interface IUpdateCommentUseCase
    {
        Task ExecuteAsync(Guid commentId, string newContent, string contente);
        Task ExecuteAsync(Guid commentId, string content);
    }
}
