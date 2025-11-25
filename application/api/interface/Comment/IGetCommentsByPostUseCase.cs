using API_de_rede_social.domain.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_de_rede_social.application.api.@interface.Comment
{
    public interface IGetCommentsByPostUseCase
    {
        Task<IEnumerable<CommentEntities>> ExecuteAsync(Guid postId);
    }
}
