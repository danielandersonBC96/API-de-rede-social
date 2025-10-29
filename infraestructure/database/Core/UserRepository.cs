using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository;

namespace API_de_rede_social.infraestructure.database.Core
{
    public class UserRepository : IUserRepository
    {
        public  readonly SocialNetworkDBContext _context;   

        public UserRepository(SocialNetworkDBContext context)
        {
            _context = context;
        }
        

        public  async Task<UserEntities> AddAsync(UserEntities user)
        {
            _context.UserEntities.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntities> GetByEmailAsync(string email)
        {
            return await _context.UserEntities.FirstOrDefaultAsync(u => u.Email == email);
        }

         public async Task<UserEntities?> GetByIdAsync(Guid userId)
        {
            return await _context.UserEntities.FindAsync(userId);
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
