using API_de_rede_social.application.api.@interface;
using API_de_rede_social.application.api.@interface.Comment;
using API_de_rede_social.application.api.@interface.Follewrs;
using API_de_rede_social.application.api.@interface.Post;
using API_de_rede_social.application.api.@interface.User;

using API_de_rede_social.application.api.usecase.Coment;
using API_de_rede_social.application.api.usecase.Follewrs;
using API_de_rede_social.application.api.usecase.post;
using API_de_rede_social.application.api.usecase.User;
using API_de_rede_social.domain.repository;
using API_de_rede_social.domain.repository.repositories;

using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------------------------
// Database Context
// -------------------------------------
builder.Services.AddDbContext<SocialNetworkDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// -------------------------------------
// Repositories
// -------------------------------------
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserFollowRepository, UserFollowRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// -------------------------------------
// UseCases - POST
// -------------------------------------
builder.Services.AddScoped<ICreatePostUseCase, CreatePostUseCase>();
builder.Services.AddScoped<IDeletPostUseCase, DeletPostUseCase>();
builder.Services.AddScoped<IGetAllPostUseCase, GetAllPostUseCase>();
builder.Services.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();

// ERRADO ANTES → builder.Services.AddScoped<IGetUserByIdUserCase, IGetUserByIdUserCase>();
// Agora correto:
builder.Services.AddScoped<ICreateUserUseCase,CreateUserUseCase>();
builder.Services.AddScoped<IDeleteUserCase,DeleteUseUserCase>();
builder.Services.AddScoped<IUpdateUserUseCase,UpdateUserUseCase>();
builder.Services.AddScoped<IDeleteUserCase, DeleteUseUserCase>();

// -------------------------------------
// UseCases - COMMENT
// -------------------------------------
builder.Services.AddTransient<ICreateCommentUseCase, CreateCommentUseCase>();
builder.Services.AddScoped<IDeleteCommentUseCase, DeleteCommentUseCase>();
builder.Services.AddScoped<IUpdateCommentUseCase, UpdateCommentUseCase>();

// -------------------------------------
// UseCases - FOLLOW SYSTEM
// -------------------------------------
builder.Services.AddScoped<IFollowUserUseCase, FollowUserUseCase>();
builder.Services.AddScoped<IUnfollowUserUseCase, UnfollowUserUseCase>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
