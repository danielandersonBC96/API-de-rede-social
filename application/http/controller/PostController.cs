using API_de_rede_social.application.api.@interface.Post;
using API_de_rede_social.application.dto;
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
        private readonly IGetPostByIdUseCase _getPostById;
        private readonly IGetAllPostUseCase _getAllPosts;

        public PostController(
            ICreatePostUseCase createPost,
            IUpdatePostUseCase updatePost,
            IDeletPostUseCase deletePost,
            IGetPostByIdUseCase getPostById,
            IGetAllPostUseCase getAllPosts)
        {
            _createPost = createPost;
            _updatePost = updatePost;
            _deletePost = deletePost;
            _getPostById = getPostById;
            _getAllPosts = getAllPosts;
        }

        // --------------------------------------------
        // Criar novo post
        // --------------------------------------------
        [HttpPost]

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatPostRequest request)
        {
            if (request == null)
                return BadRequest("Requisição inválida.");

            Guid postId = await _createPost.ExecuteAsync(request.UserId, request.Content);

            return CreatedAtAction(
                nameof(GetById),
                new { postId = postId },
                new { message = "Post criado com sucesso", id = postId }
            );
        }


        // --------------------------------------------
        // Atualizar Post
        // --------------------------------------------
        [HttpPut("{postId:guid}")]
        public async Task<IActionResult> Update(Guid postId, [FromBody] UpdatePostRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Content))
                return BadRequest("O conteúdo do post não pode ser vazio.");

            await _updatePost.ExecuteAsync(postId, request.Content);

            return Ok(new { message = "Post atualizado com sucesso." });
        }

        // --------------------------------------------
        // Deletar Post
        // --------------------------------------------
        [HttpDelete("{postId:guid}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            await _deletePost.ExecuteAsync(postId);
            return NoContent();
        }

        // --------------------------------------------
        // Buscar post por ID
        // --------------------------------------------
        [HttpGet("{postId:guid}")]
        public async Task<IActionResult> GetById(Guid postId)
        {
            var post = await _getPostById.EntitiesAsync(postId);

            if (post == null)
                return NotFound(new { message = "Post não encontrado." });

            return Ok(post);
        }

        // --------------------------------------------
        // Buscar todos os posts
        // --------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid UserId)
        {
            var posts = await _getAllPosts.ExecuteAsync(UserId);
            return Ok(posts);
        }
    }
}
