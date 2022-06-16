using blog_be.Constant;
using blog_be.Model;
using blog_be.Model.Login;
using blog_be.Model.User;
using Microsoft.EntityFrameworkCore;

namespace blog_be.Reponsitory
{
    public interface IBlogRepository
    {
        Task<IEnumerable<ListUser>> GetListUser();
    }

    public class BlogRepositoryImp : IBlogRepository
    {
        private readonly BlogContext blogContext;

        public BlogRepositoryImp(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<IEnumerable<ListUser>> GetListUser()
            => await blogContext.ListUsers
                .FromSqlRaw(BlogConstant.GetListUser)
                .ToListAsync();
    }
}