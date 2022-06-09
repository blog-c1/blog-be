namespace blog_be
{
    using blog_be.Reponsitory;
    using Microsoft.AspNetCore.Mvc;
    
    public class BlogController: Controller
    {
        private readonly BlogRepository reponsitory;

        public BlogController(BlogRepository reponsitory)
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
