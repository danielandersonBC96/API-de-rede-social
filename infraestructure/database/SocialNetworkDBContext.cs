using API_de_rede_social.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API_de_rede_social.infraestructure.database
{
    public class SocialNetworkDBContext : DbContext
    {
        public SocialNetworkDBContext(DbContextOptions<SocialNetworkDBContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<PostEntities> PostEntities { get; set; }   
        public DbSet<CommentEntities> CommentEntities { get; set; }
        public DbSet<UserFollowerEntities> UserFollowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da relação muitos-para-muitos entre UserEntities e UserFollower

            modelBuilder.Entity<UserFollowerEntities>()
                .HasKey(uf => new { uf.UserId, uf.FollowerId });
            modelBuilder.Entity<UserFollowerEntities>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserFollowerEntities>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações adicionais

            modelBuilder.Entity<PostEntities>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<CommentEntities>()
                .Property(c=> c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
