using blog_be.Data;
using blog_be.PostManagement.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace blog_be.PostManagement;

public interface IPostManagementRepository
{
    Task<List<PostInfo>> GetAllPost();

    Task<PostDetail> GetPostDetailByPostId(int postId);

    Task<List<Comment>> GetCommentsByPostId(int postId);

    Task<string> CreatePostAsync(PostCreation post);
}

public class PostManagementRepositoryImp : IPostManagementRepository
{
    private readonly BlogContext blogContext;

    public PostManagementRepositoryImp(BlogContext blogContext)
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

    public async Task<string> CreatePostAsync(PostCreation post)
    {
        var pTitle = new NpgsqlParameter("I_Title", post.Title) { Direction = ParameterDirection.Input };
        var pContent = new NpgsqlParameter("I_Content", post.Content) { Direction = ParameterDirection.Input };
        var pImage = new NpgsqlParameter("I_Image", post.Image) { Direction = ParameterDirection.Input };
        var pCategotyId = new NpgsqlParameter("I_Category_Id", post.Category_Id) { Direction = ParameterDirection.Input };
        var pResult = new NpgsqlParameter("o_result", string.Empty) { Direction = ParameterDirection.InputOutput };

        await blogContext.Database.ExecuteSqlInterpolatedAsync($"SELECT CREATE_POST({pTitle}, {pContent}, {pImage}, {pCategotyId}, {pResult})");

        return Convert.ToString(pResult.Value);
    }
}