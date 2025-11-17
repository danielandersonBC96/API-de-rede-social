namespace API_de_rede_social.domain.entities
{
    public class UserFollowerEntities
    {
        public Guid UserId { get; set; }          // o seguido
        public UserEntity User { get; set; } = default!;

        public Guid FollowerId { get; set; }      // quem segue
        public UserEntity Follower { get; set; } = default!;
    }

}