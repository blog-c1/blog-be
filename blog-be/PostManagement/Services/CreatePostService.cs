using blog_be.PostManagement.Model;

namespace blog_be.PostManagement.Services;

public interface ICreatePostService
{
    Task<string> CreatePost(PostCreation post);
}

public class CreatePostServiceImp : ICreatePostService
{
    private readonly IPostManagementRepository postRepository;

    public CreatePostServiceImp(IPostManagementRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    public async Task<string> CreatePost(PostCreation post)
        => await postRepository.CreatePostAsync(post);
}