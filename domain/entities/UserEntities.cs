using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace API_de_rede_social.domain.entities
{
    public class UserEntities
    {
        [ConfigurationKeyName("id")]

        public Guid Id { get; set; } =  Guid.NewGuid();

        public string Namme { get; set;  } = string.Empty;

        public String Email { get; set; } = string.Empty;

        public String PasswordHash { get; set; } = string.Empty;

        public ICollection<PostEntities> Post { get; set; } = new List<PostEntities>();
        public ICollection<CommentEntities> Comments { get; set; } = new List<CommentEntities>();

        // Seguidores e seguindo (self-referencing many-to-many)
        public ICollection<UserFollower> Followers { get; set; } = new List<UserFollower>();
        public ICollection<UserFollower> Following { get; set; } = new List<UserFollower>();

    }
}
