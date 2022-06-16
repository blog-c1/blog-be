using System;
using System.Collections.Generic;
using blog_be.Model.Login;
using blog_be.Model.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace blog_be.Model
{
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
        public virtual DbSet<ListUser> ListUsers { get; set; }
    }
}
