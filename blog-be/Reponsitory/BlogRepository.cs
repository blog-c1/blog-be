using blog_be.Constant;
using blog_be.Model;
using Microsoft.EntityFrameworkCore;

namespace blog_be.Reponsitory
{
    public interface BlogRepository
    {
        Task<IEnumerable<USER>> GetListUser();
    }

    public class BlogRepositoryImp : BlogRepository
    {
        private readonly BlogContext blogContext;

        public BlogRepositoryImp(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<IEnumerable<USER>> GetListUser()
            => await blogContext.USERs
                .FromSqlRaw(BlogConstant.GetListUser)
                .ToListAsync();
    }
}
