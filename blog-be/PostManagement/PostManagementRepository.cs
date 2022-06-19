using blog_be.Data;
using blog_be.PostManagement.Model;
using Microsoft.EntityFrameworkCore;


namespace blog_be.PostManagement
{
    public interface IPostManamentRepository
    {
        Task<List<PostInfo>> GetAllPost();

        Task<PostDetail> GetPostDetailByPostId(int postId);

        Task<List<Comment>> GetCommentsByPostId(int postId);

    }


    public class PostManamentRepositoryImp : IPostManamentRepository
    {
        private readonly BlogContext blogContext;

        public PostManamentRepositoryImp(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<List<PostInfo>> GetAllPost()
         => await blogContext
            .PostInfos
            .FromSqlRaw("SELECT * FROM PostManament_GetAllPosts()")
            .ToListAsync();

        public async Task<PostDetail> GetPostDetailByPostId(int postId)
            => (await blogContext
            .PostDetails
            .FromSqlRaw($"SELECT * FROM PostManament_GetPostDetailInfo({postId})")
            .ToListAsync()).FirstOrDefault();

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
            => await blogContext
            .Comments
            .FromSqlRaw($"SELECT * FROM PostManament_GetCommentsByPostId({postId})")
            .ToListAsync();
    }
}
