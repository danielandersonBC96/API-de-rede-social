using System;
using System.Collections.Generic;

namespace API_de_rede_social.domain.entities
{
    public class UserEntities
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Posts e comentários do usuário
        public ICollection<PostEntities> Posts { get; set; } = new List<PostEntities>();
        public ICollection<CommentEntities> Comments { get; set; } = new List<CommentEntities>();

        // Seguidores e seguindo (self-referencing many-to-many)
        public ICollection<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public ICollection<UserFollower> Following { get; set; } = new List<UserFollower>();
    }
}
