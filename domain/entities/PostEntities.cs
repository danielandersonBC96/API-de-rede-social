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
        public string Content { get; set; } // Conteúdo do post

        [Required]
        public Guid Userid { get; set; } // Id do usuário que criou o post

        [ForeignKey("Userid")]

        public UserEntities User { get; set; } // Referência ao usuário que criou o post

        public DateTime CreateTime { get; set; } = DateTime.UtcNow; // Data e hora de criação do post4

        public ICollection<CommentEntities> Comments { get; set; } = new List<CommentEntities>(); // Comentários associados ao post
    }
}
