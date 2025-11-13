using API_de_rede_social.domain.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_de_rede_social.domain.repository.repositories
{
    public interface ICommentsRepository
    {
        Task<CommentEntities?> GetByIdAsync(Guid commentId);
        Task<IEnumerable<CommentEntities>> GetByPostIdAsync(Guid postId);
        Task AddAsync(CommentEntities comment);
        Task UpdateAsync(CommentEntities comment);
        Task DeleteAsync(Guid commentId);
        Task SaveChangesAsync();
    }
}
