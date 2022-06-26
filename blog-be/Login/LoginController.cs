namespace blog_be.Login;

using blog_be.Login.Model;
using blog_be.Login.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

public class LoginController : ControllerBase
{
    private readonly ILoginService loginService;

    public LoginController(ILoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost("api/login")]
    public async Task<IActionResult> Authenticate([FromBody] UserRequest userRequest)
    {
        var token = await loginService.Authenticate(userRequest);
        return token is null ? Unauthorized(new { messageError = "Username or password is not correct!" }) : Ok(token);
    }

    [HttpGet("api/profile")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetUserName() => await Task.Run(() => Ok(new { username = this.User.Identity.Name}));
}