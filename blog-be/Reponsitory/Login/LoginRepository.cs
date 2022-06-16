using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using blog_be.JWTSecurity;
using blog_be.Model;
using blog_be.Model.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace blog_be.Reponsitory.Login
{
    public interface ILoginRepository
    {
        Task<Tokens> Authenticate(UserLoginInfo user);
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

        public async Task<Tokens> Authenticate(UserLoginInfo user)
        {
            var users = await blogContext.UserLoginInfos.FromSqlInterpolated($"SELECT * FROM LOGIN_GETUSERINFO({user.UserName}, {user.Pwd})").ToListAsync();

            if (users.Count > 0)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Role, users[0].Role)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { Token = tokenHandler.WriteToken(token) };
            }

            return null;
        }
    }
}
