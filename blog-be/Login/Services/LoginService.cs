namespace blog_be.Login.Services;

using blog_be.Login.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public interface ILoginService
{
    Task<Tokens> Authenticate(UserRequest user);
}

public class LoginService : ILoginService
{
    private readonly ILoginRepository loginRepository;

    private readonly IConfiguration configuration;

    public LoginService(IConfiguration configuration, ILoginRepository loginRepository)
    {
        this.configuration = configuration;
        this.loginRepository = loginRepository;
    }

    public async Task<Tokens> Authenticate(UserRequest user)
    {
        var userInfo = await loginRepository.GetUserInfo(user);

        if (userInfo is null)
        {
            return null;
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                        new Claim(ClaimTypes.Role, userInfo.Role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
}