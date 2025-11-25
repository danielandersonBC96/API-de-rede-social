using API_de_rede_social.application.api.@interface.User;
using API_de_rede_social.domain.entities;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase.User
{
    public class GetAllUseCase : IGetAllUserCase
    {
        private readonly IUserRepository _repository;
    
       public GetAllUseCase(IUserRepository repository)
        {
            _repository = repository;
        }    

        public async Task<IEnumerable<UserEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
