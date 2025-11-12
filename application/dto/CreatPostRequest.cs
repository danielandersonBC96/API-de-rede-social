namespace API_de_rede_social.application.dto
{
    public class CreatPostRequest
    {
        public Guid UserId { get; set; }; //Usuário que criou o post
        public string Content { get; set; } = string.Empty; // Testo principal do post
        public string? ImageUrl { get; set; } //image do post 

    }
}