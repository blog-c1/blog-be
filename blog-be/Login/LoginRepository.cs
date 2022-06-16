namespace blog_be.Login;

using blog_be.Data;
using blog_be.Login.Model;
using Microsoft.EntityFrameworkCore;

public interface ILoginRepository
{
    Task<UserLoginInfo> GetUserInfo(UserRequest user);
}

public class LoginRepository : ILoginRepository
{
    private readonly BlogContext blogContext;
    private readonly IConfiguration iconfiguration;

    public LoginRepository(IConfiguration iconfiguration, BlogContext blogContext)
    {
        this.iconfiguration = iconfiguration;
        this.blogContext = blogContext;
    }

    public async Task<UserLoginInfo> GetUserInfo(UserRequest user)
       => await blogContext.UserLoginInfos
        .FromSqlInterpolated($"SELECT * FROM LOGIN_GETUSERINFO({user.UserName}, {user.Password})")
        .FirstOrDefaultAsync();
}