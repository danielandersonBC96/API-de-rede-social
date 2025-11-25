using API_de_rede_social.application.api.usecase;
using API_de_rede_social.application.api.usecase.@interface;
using API_de_rede_social.application.dto;
using API_de_rede_social.application.usecases.posts;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ICreatePostUseCase _createPost;
        private readonly IUpdatePostUseCase _updatePost;
        private readonly IDeletPostUseCase _deletePost;
        private readonly IGetUserByIdUserCase _getPostById;
        private readonly IGetAllPostUseCase _getAllPosts;

        public PostController(
            ICreatePostUseCase createPost,
            IUpdatePostUseCase updatePost,
            IDeletPostUseCase deletePost,
            IGetUserByIdUserCase getPostById,
            IGetAllPostUseCase getAllPosts)
        {
            _createPost = createPost;
            _updatePost = updatePost;
            _deletePost = deletePost;
            _getPostById = getPostById;
            _getAllPosts = getAllPosts;
        }

        // Criar novo Post
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatPostRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Requisição inválida." });

            var post = await _createPost.ExecuteAsync(request.UserId, request.Content);

            return Ok(new
            {
                message = "Post criado com sucesso.",
                data = post
            });
        }

        // Atualizar Post
        [HttpPut("{postId}")]
        public async Task<IActionResult> Update(Guid postId, [FromBody] UpdatePostRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Content))
                return BadRequest(new { message = "O conteúdo do post não pode ser vazio." });

            await _updatePost.ExecuteAsync(postId, request.Content);

            return Ok(new { message = "Post atualizado com sucesso." });
        }

        // Deletar Post
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            await _deletePost.ExecuteAsync(postId);
            return NoContent();
        }

        // Buscar post por ID
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(Guid postId)
        {
            var post = await _getPostById.ExecuteAsync(postId);

            if (post == null)
                return NotFound(new { message = "Post não encontrado." });

            return Ok(post);
        }

        // Buscar todos os posts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _getAllPosts.ExecuteAsync();
            return Ok(posts);
        }
    }
}
