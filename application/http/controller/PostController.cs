using API_de_rede_social.application.api.usecase;
using API_de_rede_social.application.api.usecase.@interface;
using API_de_rede_social.application.dto;
using API_de_rede_social.application.usecases.comments;
using API_de_rede_social.application.usecases.posts;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostController : ControllerBase
    {

        private readonly ICreatePostUseCase _create;
        private readonly IUpdateCommentUseCase _update;
        private readonly IDeletPostUseCase _delete;
        private readonly IGetPostByIdUseCase _getbyid;
        private readonly IGetAllPostUseCase _getAll;


        public PostController(

             ICreatePostUseCase create,
             IUpdateCommentUseCase update,
             IDeletPostUseCase delete,
             IGetPostByIdUseCase getById,
             IGetAllPostUseCase getAll


             )
        {
            _create = create;
            _update = update;
            _delete = delete;
            _getbyid = getById;
            _getAll = getAll; 

        }

        //Criar um novo post 

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreatPostRequest request)
        {

            if (request == null)
                return BadRequest(new { message = "Requisição invalida" });

            await _create.ExecuteAsync(request.UserId, request.Content, request.Content);
            return Ok(new { message = "Comentário criado com sucesso." });

        }

        //Atualizar Post 

        [HttpPost("{postId}")]
        public async Task<IActionResult> update(Guid postId, [FromBody] UpdatePostRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Contente))
                return BadRequest(new { message = "O conteuso do post não pode ser vazio" });

            await _update.ExecuteAsync(postId, request.Contente, request.Contente);
            return Ok(new { message = "Comentário criado com sucesso." });

        }

        //Deletar Post

        [HttpDelete("{postId}")]
        public async Task<IActionResult>delete(Guid postId)
        {
            await _delete.ExecuteAsync(postId);
            return NoContent();
        }

        //Buscar post por ID
       
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(Guid postId)
        {
            var post = await _getbyid.ExecuteAsync(postId);

            if (post == null)
                return NotFound(new { message = "Post não encontrado." });

            return Ok(post);
        }

        //Buscar todos os post 
        
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {

            var posts = await _getAll.ExecuteAsync();
            return Ok(posts);
        }


    }
}
