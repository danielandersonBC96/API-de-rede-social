namespace API_de_rede_social.application.dto
{
    public class UnFollowRequest
    {
        public Guid FollowerId { get; set; }
        public Guid FolloweeId { get; set; }
    }
}
