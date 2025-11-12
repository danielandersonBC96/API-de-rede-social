namespace API_de_rede_social.application.dto
{
    public class UpdatePostRequest
    {
        public Guid PostId { get; set; } //ID do post a ser atualizado
        public string Contente { get; set; } = string.Empty;//Novo Conteudo

        public string? ImageUrl { get; set;} //Nova Imagem
    }
}