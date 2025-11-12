namespace API_de_rede_social.application.dto
{
    public class CreateCommentRequest
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
