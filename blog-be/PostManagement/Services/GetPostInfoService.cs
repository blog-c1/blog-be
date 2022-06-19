using blog_be.PostManagement.Model;

namespace blog_be.PostManagement.Services
{
    public interface IGetPostInfoService
    {
        public Task<List<PostInfo>> GetAllPosts();

        public Task<PostDetail> GetPostDetail(int postId);
    }


    public class GetPostInfoServiceImp: IGetPostInfoService
    {
        private readonly IPostManamentRepository postManamentRepository;

        public GetPostInfoServiceImp( IPostManamentRepository postManamentRepository)
        {
            this.postManamentRepository  = postManamentRepository;
        }

        public async Task<List<PostInfo>> GetAllPosts()
         => await postManamentRepository.GetAllPost();

        public async Task<PostDetail> GetPostDetail(int postId)
        {
            var post = await postManamentRepository.GetPostDetailByPostId(postId);
            var comments = await postManamentRepository.GetCommentsByPostId(postId);
            post.Comments = comments;
            return post;
        }
    }
}
