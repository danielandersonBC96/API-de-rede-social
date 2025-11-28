using API_de_rede_social.application.api.@interface;
using API_de_rede_social.application.api.@interface.Comment;
using API_de_rede_social.application.dto;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICreateCommentUseCase _create;
        private readonly IUpdateCommentUseCase _update;
        private readonly IDeleteCommentUseCase _delete;
        private readonly IGetCommentsByPostUseCase _getByPost;

        public CommentController(

            ICreateCommentUseCase create,
            IUpdateCommentUseCase update,
            IDeleteCommentUseCase delete,
            IGetCommentsByPostUseCase getByPost)
        {
            _create = create;
            _update = update;
            _delete = delete;
            _getByPost = getByPost;
        }

        //  Criação de comentário

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Requisição inválida." });

            await _create.ExecuteAsync(request.UserId, request.PostId, request.Content);
            return Ok(new { message = "Comentário criado com sucesso." });
        }

        //  Atualização de comentário

        [HttpPut("{commentId}")]
        public async Task<IActionResult> Update(Guid commentId, [FromBody] string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return BadRequest(new { message = "O conteúdo do comentário não pode ser vazio." });

            await _update.ExecuteAsync(commentId, content);
            return Ok(new { message = "Comentário atualizado com sucesso." });
        }

        //  Exclusão de comentário

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(Guid commentId)
        {
            await _delete.ExecuteAsync(commentId);
            return NoContent();
        }

        // Listagem de comentários por post

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetByPost(Guid postId)
        {
            var comments = await _getByPost.ExecuteAsync(postId);

            if (comments == null || !comments.Any())
                return NotFound(new { message = "Nenhum comentário encontrado para este post." });

            return Ok(comments);
        }
    }
}
