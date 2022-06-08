using Microsoft.EntityFrameworkCore;

namespace blog_be.Model
{
    public partial class BlogContext : DbContext
    {

        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        {
        }

        public virtual DbSet<USER> USERs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

