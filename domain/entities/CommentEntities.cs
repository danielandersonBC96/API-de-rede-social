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
        public string Content { get; set; } // Conteúdo do comentário
        [Required]

        public Guid PostId { get; set; } // Id do post ao qual o comentário pertence

        [ForeignKey('PostId')]
        public PostEntities Post { get; set; } // Referência ao post associado ao comentário
        public DateTime CreateTime { get; set; } = DateTime.UtcNow; // Data e hora de criação do comentário
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow; // Data e hora da última atualização do comentário

        [Required]
        public Guid UserId { get; set; } // Id do usuário que criou o comentário

        [ForeignKey("UserId")]
        public UserEntities User { get; set; } // Referência ao usuário que criou o comentário

        public DateTime CreateAt { get; set; } = DateTim.utcNow;



    }
}