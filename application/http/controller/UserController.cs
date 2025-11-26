using API_de_rede_social.application.api.@interface.User;
using API_de_rede_social.domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUser;
        private readonly IGetUserByIdUserCase _getById;
        private readonly IGetAllUserCase _getAll;
        private readonly IUpdateUserUseCase _updateUser;
        private readonly IDeleteUserCase _deleteUser;

        public UserController(
            ICreateUserUseCase createUser,
            IGetUserByIdUserCase getById,
            IGetAllUserCase getAll,
            IUpdateUserUseCase updateUser,
            IDeleteUserCase deleteUser)
        {
            _createUser = createUser;
            _getById = getById;
            _getAll = getAll;
            _updateUser = updateUser;
            _deleteUser = deleteUser;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserEntity request)
        {
            var created = await _createUser.ExecuteAsync(request.Name, request.Email);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _getById.ExecuteAsync(id);
            return user is null ? NotFound() : Ok(user);
        }


        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _getAll.ExecuteAsync();
            return Ok(users);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserEntity request)
        {
            var updated = await _updateUser.ExecuteAsync(id, request.Name, request.Email);
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteUser.ExecuteAsync(id);
            return NoContent();
        }
    }
}
