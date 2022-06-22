using blog_be.PostManagement.Model;

namespace blog_be.PostManagement.Services
{
    public interface IPostService
    {
        Task<string> CreatePost(PostCreation post);

        Task<List<PostInfo>> GetAllPosts();

        Task<PostDetail> GetPostDetail(int postId);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
    
        public async Task<string> CreatePost(PostCreation post)
        {
            var rs = await postRepository.CreatePostAsync(post);
            return rs;
        }

        public async Task<List<PostInfo>> GetAllPosts()
         => await postRepository.GetAllPost();

        public async Task<PostDetail> GetPostDetail(int postId)
        {
            var post = await postRepository.GetPostDetailByPostId(postId);
            var comments = await postRepository.GetCommentsByPostId(postId);
            post.Comments = comments;
            return post;
        }
    }
}
