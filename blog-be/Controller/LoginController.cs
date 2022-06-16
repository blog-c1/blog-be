using blog_be.Model.Login;
using blog_be.Reponsitory.Login;
using Microsoft.AspNetCore.Mvc;

namespace blog_be.Controller
{
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _iLoginRepository;

        public LoginController(ILoginRepository iLoginRepository)
        {
            this._iLoginRepository = iLoginRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(UserLoginInfo userLoginInfo)
        {
            var token = await _iLoginRepository.Authenticate(userLoginInfo);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
