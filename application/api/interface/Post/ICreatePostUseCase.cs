public interface ICreatePostUseCase
{
    Task<Guid> ExecuteAsync(Guid userId, string content, string? imageUrl = null);
}
