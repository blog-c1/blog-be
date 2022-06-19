namespace blog_be.Data;

using blog_be.Login.Model;
using blog_be.PostManament.Model;
using Microsoft.EntityFrameworkCore;

public partial class BlogContext : DbContext
{
    public BlogContext()
    {
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLoginInfo> UserLoginInfos { get; set; }

    public virtual DbSet<PostInfo> PostInfos { get; set; }
}