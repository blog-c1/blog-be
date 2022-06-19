using blog_be.Data;
using blog_be.PostManament.Model;
using Microsoft.EntityFrameworkCore;

namespace blog_be.PostManament
{
    public interface IPostManamentRepository
    {
        Task<List<PostInfo>> GetAllPost();
    }


    public class PostManamentRepositoryImp : IPostManamentRepository
    {
        private readonly BlogContext blogContext;

        public PostManamentRepositoryImp(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<List<PostInfo>> GetAllPost()
        => await blogContext.PostInfos.FromSqlRaw("SELECT * FROM PostManament_GetallPosts()").ToListAsync();
    }
}
