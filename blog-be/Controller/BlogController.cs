namespace blog_be.Controller
{
    using blog_be.Reponsitory;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "admin")]
    public class BlogController : Controller
    {
        private readonly IBlogRepository reponsitory;

        public BlogController(IBlogRepository reponsitory)
        {
            this.reponsitory = reponsitory;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetListUser()
        {
            var user = await reponsitory.GetListUser();
            return Ok(user);
        }
    }
}