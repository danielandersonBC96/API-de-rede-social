using API_de_rede_social.Application.Service;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntity> CreateAsync(string name, string email)
        {
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreatedAt = DateTime.UtcNow
            };

            return await _userRepository.AddAsync(user);
        }

        public async Task<UserEntity> UpdateAsync(Guid id, string name, string email)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Usuário não encontrado.");

            existing.Name = name;
            existing.Email = email;

            return await _userRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();
        }
    }
}
