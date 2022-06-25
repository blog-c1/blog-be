namespace blog_be.Login;

using blog_be.Login.Model;
using blog_be.Login.Services;
using Microsoft.AspNetCore.Mvc;

public class LoginController : ControllerBase
{
    private readonly ILoginService loginService;

    public LoginController(ILoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost("api/login")]
    public async Task<IActionResult> Authenticate(UserRequest userRequest)
    {
        var token = await loginService.Authenticate(userRequest);

        return token is null ? Unauthorized() : Ok(token);
    }
}