using API_de_rede_social.application.api.usecase.Coment;
using API_de_rede_social.application.api.usecase.Follewrs;
using API_de_rede_social.application.api.usecase.post;
using API_de_rede_social.domain.repository;
using API_de_rede_social.domain.repository.repositories;
using API_de_rede_social.infraestructure.database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------------
// Database Context
// -------------------------

builder.Services.AddDbContext<SocialNetworkDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// -------------------------
// Repositories
// -------------------------

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserFollowRepository, UserFollowRepository>();

// -------------------------
// UseCases - POST
// -------------------------
builder.Services.AddScoped<ICreatePostUseCase, CreatePostUseCase>();
builder.Services.AddScoped<IDeletPostUseCase, DeletPostUseCase>();
builder.Services.AddScoped<IGetUserByIdUserCase, IGetUserByIdUserCase>();
builder.Services.AddScoped<IGetAllPostUseCase, IGetAllPostUseCase>();


// UseCases - COMMENT
// -------------------------
builder.Services.AddScoped<IUpdateCommentUseCase, UpdateCommentUseCase>();

// -------------------------
// UseCases - USER FOLLOW
// -------------------------
builder.Services.AddScoped<IFollowUserActionUseCase,IFollowUserActionUseCase>();
builder.Services.AddScoped<IUnfollowUserUseCase, UnfollowUserUseCase>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
