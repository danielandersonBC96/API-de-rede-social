using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.api.@interface.Comment
{
    public interface IDeleteCommentUseCase
    {
        Task ExecuteAsync(Guid commentId);
    }
}
