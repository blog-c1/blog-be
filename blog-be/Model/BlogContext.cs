using System;
using System.Collections.Generic;
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

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=ec2-34-194-73-236.compute-1.amazonaws.com;Port=5432;Database=d4rfaofai5rbj3;UserId=uibtvezizinzaf;Password=580674a6b0d2d422a8a365bfebee2feb1ff8cac59dafb47758d81ab058627631");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('\"User_id_seq\"'::regclass)");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DelFlg).HasColumnName("del_flg");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(100)
                    .HasColumnName("pwd")
                    .IsFixedLength();

                entity.Property(e => e.Role)
                    .HasMaxLength(4)
                    .HasColumnName("role")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("user_name")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
