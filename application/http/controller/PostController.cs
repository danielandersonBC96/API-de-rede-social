using API_de_rede_social.application.api.usecase;
using API_de_rede_social.application.api.usecase.@interface;
using API_de_rede_social.application.usecases;
using API_de_rede_social.application.usecases.comments;
using API_de_rede_social.application.usecases.posts;
using Microsoft.AspNetCore.Mvc;

namespace API_de_rede_social.application.http.controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class PostController : ControllerBase
    {
        readonly ICreateCommentUseCase _create,
        readonly IUpdateCommentUseCase _update,


         

    }
}
