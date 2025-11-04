using System;
using System.Threading.Tasks;

namespace API_de_rede_social.application.usecases.comments
{
    public interface IDeleteCommentUseCase
    {
        Task ExecuteAsync(Guid commentId);
    }
}
