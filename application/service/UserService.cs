using API_de_rede_social.domain.entities;
using API_de_rede_social.Domain.Repository;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace API_de_rede_social.application.service
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;
        private readonly UserEntities user;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntities> GetByIdAsync(Guid userId)
        {

            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<UserEntities>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntities> CreateAsync(string name, string email)
        {
            var uaer= new UserEntities
            {
                Id = Guid.NewGuid(),
                Name =  name,
                Email = email,
                CreatedAt = DateTime.UtcNow
            };
            return await _userRepository.AddAsync(user);
        }

    }
}
