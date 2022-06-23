using blog_be.PostManagement.Model;

namespace blog_be.PostManagement.Services
{
    public interface IGetPostInfoService
    {
        Task<List<PostInfo>> GetAllPosts();

        Task<PostDetail> GetPostDetail(int postId);
    }

    public class GetPostInfoServiceImp : IGetPostInfoService
    {
        private readonly IPostManagementRepository postRepository;

        public GetPostInfoServiceImp(IPostManagementRepository postRepository)
        {
            this.postRepository = postRepository;
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