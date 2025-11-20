
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_de_rede_social.domain.entities
{
    public class PostEntities
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Id único para cada post

        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty; // Conteúdo do post

        [Required]
        public Guid UserId { get; set; } // Id do usuário que criou o post

        [ForeignKey("UserId")]
        public UserEntity User { get; set; } = null!; // Referência ao usuário que criou o post


        public ICollection<CommentEntities> Comments { get; set; } = new List<CommentEntities>(); // Comentários associados ao post
        public string? ImageUrl { get; internal set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
