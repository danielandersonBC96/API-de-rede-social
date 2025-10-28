namespace API_de_rede_social.domain.entities
{
    public class UserFollower
    {
        public Guid UserId{ get; set; }

        public UserEntities User { get; set; }

        public Guid FollowerId { get; set; }

        public UserEntities Follower { get; set; }

      
    }
}