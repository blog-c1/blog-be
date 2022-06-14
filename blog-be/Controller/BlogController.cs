namespace blog_be.Controller
{
    using blog_be.Reponsitory;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : Controller
    {
        private readonly IBlogRepository reponsitory;

        public BlogController(IBlogRepository reponsitory)
        {
            this.reponsitory = reponsitory;
        }

        [HttpGet("getlistuser")]
        public async Task<IActionResult> GetListUser()
        {
            var user = await reponsitory.GetListUser();
            return Ok(user);
        }
    }
}