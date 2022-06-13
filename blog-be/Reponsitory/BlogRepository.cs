using blog_be.Constant;
using blog_be.Model;
using Microsoft.EntityFrameworkCore;

namespace blog_be.Reponsitory
{
    public interface IBlogRepository
    {
        Task<IEnumerable<User>> GetListUser();
    }

    public class BlogRepositoryImp : IBlogRepository
    {
        private readonly BlogContext blogContext;

        public BlogRepositoryImp(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<IEnumerable<User>> GetListUser()
            => await blogContext.Users
                .FromSqlRaw(BlogConstant.GetListUser)
                .ToListAsync();
    }
}