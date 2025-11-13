namespace API_de_rede_social.domain.entities
{
    public class UserFollower
    {
        public Guid UserId{ get; set; }

        public UserEntity User { get; set; }

        public Guid FollowerId { get; set; }

        public UserEntity Follower { get; set; }

      
    }
}