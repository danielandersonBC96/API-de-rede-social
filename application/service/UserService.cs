using API_de_rede_social.Application.Service;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace API_de_rede_social.application.service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly UserEntity user;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> GetByIdAsync(Guid userId)
        {

            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntity> CreateAsync(string name, string email)
        {
            var uaer= new UserEntity
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
