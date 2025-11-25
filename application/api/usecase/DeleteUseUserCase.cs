using API_de_rede_social.application.api.usecase.@interface;
using API_de_rede_social.domain.repository.repositories;

namespace API_de_rede_social.application.api.usecase
{
    public class DeleteUseUserCase : IDeleteUserCase
    {

        private readonly IUserRepository _repository;

        public DeleteUseUserCase(

             IUserRepository repository
            )
        {
            _repository = repository;

        }

        public async Task ExecuteAsync(Guid id )
        {
            await _repository.DeleteAsync(id);
        }
    }
}
