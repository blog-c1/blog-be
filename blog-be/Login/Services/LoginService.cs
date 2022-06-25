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

public class LoginServiceImp : ILoginService
{
    private readonly ILoginRepository loginRepository;

    private readonly IConfiguration configuration;

    public LoginServiceImp(IConfiguration configuration, ILoginRepository loginRepository)
    {
        this.configuration = configuration;
        this.loginRepository = loginRepository;
    }

    public async Task<Tokens> Authenticate(UserRequest user)
    {
        var userLoginInfo = await loginRepository.GetUserInfo(user);

        if (userLoginInfo is null)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                        new Claim(ClaimTypes.Name, userLoginInfo.UserName),
                        new Claim(ClaimTypes.Role, userLoginInfo.Role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token), RefreshToken = tokenDescriptor.Expires.ToString()};
    }
}