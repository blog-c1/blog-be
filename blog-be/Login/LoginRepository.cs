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

    public LoginRepository( BlogContext blogContext)
    {
        this.blogContext = blogContext;
    }

    public async Task<UserLoginInfo> GetUserInfo(UserRequest user)
       => await blogContext.UserLoginInfos
        .FromSqlInterpolated($"SELECT * FROM LOGIN_GETUSERINFO({user.UserName}, {user.Password})")
        .FirstOrDefaultAsync();
}