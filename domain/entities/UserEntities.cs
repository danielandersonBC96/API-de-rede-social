using System;
using System.Collections.Generic;

namespace API_de_rede_social.domain.entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;

        // Quem me segue
        public ICollection<UserFollowerEntities>? Followers { get; set; }

        // Quem eu sigo
        public ICollection<UserFollowerEntities>? Following { get; set; }
    }
}
