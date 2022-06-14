using blog_be.JWTSecurity;
using blog_be.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace blog_be.Reponsitory.Login
{
    public interface ILoginRepository
    {
        Tokens Authenticate(User user);
        Task<IEnumerable<User>> GetListUserAsync();
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

        public Tokens Authenticate(User user)
        {
            var checkUser = blogContext.Users.Count(u => u.UserName.Equals(user.UserName) && u.Pwd.Equals(user.Pwd));

            if (checkUser > 0)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { Token = tokenHandler.WriteToken(token) };
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetListUserAsync() => await blogContext.Users.Where(u => u.DelFlg == true).ToListAsync();
    }
}
