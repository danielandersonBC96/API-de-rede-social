using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_de_rede_social.domain.entities
{
    public class CommentEntities
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Id único para cada comentário

        [Required]
        [MaxLength(300)]
        public string Content { get; set; } = string.Empty; // Conteúdo do comentário

        // Relacionamento com Post
        [Required]
        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        public PostEntities Post { get; set; } = null!;

        // Relacionamento com User
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; } = null!;

        // Datas
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
