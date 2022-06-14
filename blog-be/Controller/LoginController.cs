using blog_be.Model;
using blog_be.Reponsitory.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Authenticate(User usersdata)
        {
            var token = _iLoginRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetListUsers()
        {
            var user = await _iLoginRepository.GetListUserAsync();
            return Ok(user) ;
        }
    }
}
